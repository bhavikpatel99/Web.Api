using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Service.Abstracion
{
    public interface ITenantService
    {
        Task<Guid> CreateTenantAsync(string name);
    }
}
