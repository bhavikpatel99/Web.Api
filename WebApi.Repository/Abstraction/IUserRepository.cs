using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Repository.Abstraction
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersByTenantAsync(Guid tenantId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
