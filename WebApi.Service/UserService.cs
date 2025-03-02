using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Repository.Abstraction;
using WebApi.Service.Abstracion;

namespace WebApi.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Guid tenantId) => await _userRepository.GetUsersByTenantAsync(tenantId);
        public async Task CreateUserAsync(User user) => await _userRepository.CreateUserAsync(user);
        public async Task UpdateUserAsync(User user) => await _userRepository.UpdateUserAsync(user);
        public async Task DeleteUserAsync(Guid id) => await _userRepository.DeleteUserAsync(id);
    }
}
