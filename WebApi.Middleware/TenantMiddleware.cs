using Microsoft.AspNetCore.Http;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Tenant-Id", out var tenantId))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Tenant-Id is required in the headers");
                return;
            }

            context.Items["TenantId"] = tenantId.ToString();
            await _next(context);
        }
    }

}
