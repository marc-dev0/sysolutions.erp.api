using Dapper;
using Microsoft.SqlServer.Server;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class EntryNoteRepository : IEntryNoteRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EntryNoteRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(EntryNote request)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.EntryNoteInsertUpdate";
                    var parameters = new DynamicParameters();
                    parameters.Add("EntryNoteId", request.EntryNoteId);
                    parameters.Add("Correlative", request.Correlative);
                    parameters.Add("State", request.State);
                    parameters.Add("CostPriceTotal", request.CostPriceTotal);
                    parameters.Add("RegistrationAccountId", request.RegistrationAccountId);
                    parameters.Add("EntryNoteList", GetTableValuedParameter(request.EntryDetails));

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static IEnumerable<SqlDataRecord> CreateSqlDataRecord(IEnumerable<EntryNoteDetail> entryNoteDetails)
        {
            SqlMetaData[] columns = new SqlMetaData[6];
            columns[0] = new SqlMetaData("Id", SqlDbType.Int);
            columns[1] = new SqlMetaData("Quantity", SqlDbType.Int);
            columns[2] = new SqlMetaData("CostPrice", SqlDbType.Decimal, 16, 6);
            columns[3] = new SqlMetaData("ProductId", SqlDbType.Int);
            columns[4] = new SqlMetaData("EntryNoteId", SqlDbType.Int);
            columns[5] = new SqlMetaData("ProductPresentationId", SqlDbType.Int);
            var record = new SqlDataRecord(columns);
            foreach (var item in entryNoteDetails)
            {
                record.SetInt32(0, item.EntryNoteId);
                record.SetInt32(1, item.Quantity);
                record.SetDecimal(2, item.CostPrice);
                record.SetInt32(3, item.ProductId);
                record.SetInt32(4, item.EntryNoteId);
                record.SetInt32(5, item.ProductPresentationId);
                yield return record;
            }
        }

        private static SqlMapper.ICustomQueryParameter GetTableValuedParameter(IEnumerable<EntryNoteDetail> entryNoteDetails)
        {
            return CreateSqlDataRecord(entryNoteDetails).AsTableValuedParameter("EntryNoteList");
        }
    }
}
