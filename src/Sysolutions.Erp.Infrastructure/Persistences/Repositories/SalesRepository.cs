using Dapper;
using Microsoft.Extensions.Logging;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger<SalesRepository> _logger;

        public SalesRepository(IConnectionFactory connectionFactory, ILogger<SalesRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }
        public async Task<BaseSalesOrder> GetAllAsync(SalesOrder request)
        {
            var response = new BaseSalesOrder();
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.SalesOrderGetAll";
                    var parameters = new DynamicParameters();
                    parameters.Add("First", request.First);
                    parameters.Add("Rows", request.Rows);
                    response.SalesOrder = await connection.QueryAsync<SalesOrder>(query, param: parameters, commandType: CommandType.StoredProcedure);

                    foreach (var item in response.SalesOrder)
                    {
                        query = "dbo.SalesOrderDetailGetAll";
                        parameters = new DynamicParameters();
                        parameters.Add("SalesOrderId", item.SalesOrderId);
                        parameters.Add("First", request.First);
                        parameters.Add("Rows", request.Rows);
                        item.Detail = await connection.QueryAsync<SalesOrderDetail>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<bool> InsertAsync(SalesOrder salesOrder)
        {
            int salesOrderId = 0;
            DynamicParameters parameters;
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        
                        var query = "dbo.SalesOrderInsert";
                        parameters = new DynamicParameters();
                        parameters.Add("Comment", salesOrder.Comment);
                        parameters.Add("Total", salesOrder.Total);
                        parameters.Add("State", salesOrder.State);
                        parameters.Add("RegistrationAccountId", salesOrder.RegistrationAccountId);
                        parameters.Add("SalesOrderId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        var result = await connection.ExecuteAsync(query, param: parameters, transaction, commandType: CommandType.StoredProcedure);
                        salesOrderId = parameters.Get<int>("SalesOrderId");
                        _logger.LogInformation("SalesOrder Cabecera ingresado", salesOrderId.ToString());

                        if (salesOrderId < 0) { transaction.Rollback(); } else
                        {
                            foreach (var item in salesOrder.Detail)
                            {
                                item.SalesOrderId = salesOrderId;
                                query = "dbo.SalesOrderDetailInsert";
                                parameters = new DynamicParameters();
                                parameters.Add("Amount", item.Amount);
                                parameters.Add("Price", item.Price);
                                parameters.Add("ProductId", item.ProductId);
                                parameters.Add("SalesOrderId", item.SalesOrderId);
                                result += await connection.ExecuteAsync(query, param: parameters, transaction, commandType: CommandType.StoredProcedure);
                                _logger.LogInformation("SalesOrder Detalle ingresado", item.ToString() + "ProductId:" + item.ProductId);
                                if (result < 0)
                                {
                                    transaction.Rollback();
                                    break;
                                }
                            }
                        }
                        if (result > 0)
                            transaction.Commit();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
