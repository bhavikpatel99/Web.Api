using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Service.Abstracion;

[Route("api/[controller]")]
[ApiController]
public class TenantController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTenant([FromBody] Tenant tenant)
    {
        if (tenant == null || string.IsNullOrWhiteSpace(tenant.Name))
            return BadRequest("Invalid tenant data");

        var tenantId = await _tenantService.CreateTenantAsync(tenant.Name);
        return Ok(new { TenantId = tenantId, Message = "Tenant created successfully" });
    }
}
