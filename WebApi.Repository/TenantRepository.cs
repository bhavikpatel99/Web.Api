using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Abstraction;

namespace WebApi.Repository
{
    public class TenantRepository : ITenantRepository
    {
        private readonly string _connectionString;

        public TenantRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Guid> CreateTenantAsync(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("Name", name);
            parameters.Add("Id", dbType: DbType.Guid, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("sp_CreateTenant", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<Guid>("Id");
        }
    }
}
