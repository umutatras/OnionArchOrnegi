using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Domain.Identity;
using OnionArchOrnegi.Domain.Settings;
using OnionArchOrnegi.Persistence.Contexts;

namespace OnionArchOrnegi.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<OnionArchOrnegiDbContext>(opt => opt.UseNpgsql(connectionString));
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<OnionArchOrnegiDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork, OnionArchOrnegi.Persistence.UnitOfWork.UnitOfWork>();
        return services;
    }
}
