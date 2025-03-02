using WebApi.Middleware;
using WebApi.Repository.Abstraction;
using WebApi.Repository;
using WebApi.Service.Abstracion;
using WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Middleware pipeline
//app.UseMiddleware<RequestLoggingMiddleware>(); // Logs requests
//app.UseMiddleware<TenantMiddleware>();        // Extracts tenant ID
//app.UseMiddleware<ExceptionHandlingMiddleware>(); // Handles global exceptions

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
