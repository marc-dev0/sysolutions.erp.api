﻿using Dapper;
using Microsoft.SqlServer.Server;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> DeleteAsync(int productId, int modifiedAccountId)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.ProductDelete";
                    var parameters = new DynamicParameters();
                    parameters.Add("ProductId", productId);
                    parameters.Add("ModifiedAccountId", modifiedAccountId);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "ProductGetAll";
                    var parameters = new DynamicParameters();

                    var reader = await connection.QueryMultipleAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    //var response = await connection.QueryAsync<Product>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    var response = reader.Read<Product>().ToList();
                    var presentation = reader.Read<ProductPresentation>().ToList();

                    response.ForEach(x => x.productPresentations = new List<ProductPresentation>());
                    response.ForEach(x => x.productPresentations.AddRange(
                        presentation.Where(y => y.ProductId == x.ProductId)
                    ));
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductPresentation>> GetPresentationsByProductId(int productId)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.ProductPresentationGetByProductId";
                    var parameters = new DynamicParameters();
                    parameters.Add("ProductId", productId);

                    var response = await connection.QueryAsync<ProductPresentation>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var query = "dbo.ProductGetById";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", productId);


                var reader = await connection.QueryMultipleAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                var response = reader.ReadFirst<Product>();
                var presentation = reader.Read<ProductPresentation>().ToList();

                response.productPresentations = new List<ProductPresentation>();
                response.productPresentations.AddRange(presentation);
                return response;
            }
        }

        public async Task<bool> InsertAsync(Product request)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.ProductInsertUpdate";
                    var parameters = new DynamicParameters();
                    parameters.Add("ProductId", request.ProductId);
                    parameters.Add("Description", request.Description);
                    parameters.Add("Code", request.Code);
                    parameters.Add("CategoryId", request.CategoryId);
                    parameters.Add("SubCategoryId", request.SubCategoryId);
                    parameters.Add("BrandId", request.BrandId);
                    parameters.Add("State", request.State);
                    parameters.Add("AccountId", request.RegistrationAccountId);
                    parameters.Add("ProductPresentationList", GetTableValuedParameter(request.productPresentations));

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Product request)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.ProductInsertUpdate";
                    var parameters = new DynamicParameters();
                    parameters.Add("ProductId", request.ProductId);
                    parameters.Add("Description", request.Description);
                    parameters.Add("Code", request.Code);
                    parameters.Add("CategoryId", request.CategoryId);
                    parameters.Add("SubCategoryId", request.SubCategoryId);
                    parameters.Add("BrandId", request.BrandId);
                    parameters.Add("State", request.State);
                    parameters.Add("AccountId", request.RegistrationAccountId);
                    parameters.Add("ProductPresentationList", GetTableValuedParameter(request.productPresentations));

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static IEnumerable<SqlDataRecord> CreateSqlDataRecord(IEnumerable<ProductPresentation> productPresentations)
        {
            SqlMetaData[] columns = new SqlMetaData[7];
            columns[0] = new SqlMetaData("Id", SqlDbType.Int);
            columns[1] = new SqlMetaData("EquivalentQuantity", SqlDbType.Int);
            columns[2] = new SqlMetaData("Price", SqlDbType.Decimal, 16, 6);
            columns[3] = new SqlMetaData("BarCode", SqlDbType.VarChar, 15);
            columns[4] = new SqlMetaData("Hierarchy", SqlDbType.Int);
            columns[5] = new SqlMetaData("MeasureFromId", SqlDbType.Int);
            columns[6] = new SqlMetaData("MeasureToId", SqlDbType.Int);
            var record = new SqlDataRecord(columns);
            foreach (var item in productPresentations)
            {
                record.SetInt32(0, item.ProductPresentationId);
                record.SetInt32(1, item.EquivalentQuantity);
                record.SetDecimal(2, item.Price);
                record.SetString(3, item.BarCode);
                record.SetInt32(4, item.Hierarchy);
                record.SetInt32(5, item.MeasureFromId);
                record.SetInt32(6, item.MeasureToId);
                yield return record;
            }
        }

        private static SqlMapper.ICustomQueryParameter GetTableValuedParameter(IEnumerable<ProductPresentation> productPresentations)
        {
            return CreateSqlDataRecord(productPresentations).AsTableValuedParameter("ProductPresentationList");
        }
    }
}
