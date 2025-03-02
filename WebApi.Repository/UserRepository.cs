using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Repository.Abstraction;

namespace WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<User>> GetUsersByTenantAsync(Guid tenantId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<User>("sp_GetUsersByTenant", new { TenantId = tenantId }, commandType: CommandType.StoredProcedure);
        }

        public async Task CreateUserAsync(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            DynamicParameters obj = new DynamicParameters();
            obj.Add("@Name", user.Name);
            obj.Add("@Email", user.Email);
            obj.Add("@TenantId", user.TenantId);
            await connection.ExecuteAsync("sp_CreateUser", obj, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateUserAsync(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            DynamicParameters obj = new DynamicParameters();
            obj.Add("@Name", user.Name);
            obj.Add("@Email", user.Email);
            obj.Add("@Id", user.Id);
            await connection.ExecuteAsync("sp_UpdateUser", obj, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("sp_DeleteUser", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
