﻿using Dapper;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MeasureRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Measure>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "MeasureGetAll";
                    var parameters = new DynamicParameters();

                    var response = await connection.QueryAsync<Measure>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertAsync(Measure request)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.MeasureInsert";
                    var parameters = new DynamicParameters();
                    parameters.Add("Description", request.Description);
                    parameters.Add("ShortDescription", request.ShortDescription);
                    parameters.Add("State", request.State);
                    parameters.Add("RegistrationAccountId", request.RegistrationAccountId);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
