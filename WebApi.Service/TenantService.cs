using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Abstraction;
using WebApi.Service.Abstracion;

namespace WebApi.Service
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<Guid> CreateTenantAsync(string name) => await _tenantRepository.CreateTenantAsync(name);
    }
}
