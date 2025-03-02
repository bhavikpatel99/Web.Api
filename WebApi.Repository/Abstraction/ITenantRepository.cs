using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Repository.Abstraction
{
    public interface ITenantRepository
    {
        Task<Guid> CreateTenantAsync(string name);
    }

}
