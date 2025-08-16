using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Infrastructure.Services;
namespace OnionArchOrnegi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IJwtService, JwtManager>();

        services.AddScoped<IIdentityService, IdentityManager>();

        return services;
    }
}