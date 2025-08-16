using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionArchOrnegi.Domain.Entities;
using OnionArchOrnegi.Domain.Identity;

namespace OnionArchOrnegi.Persistence.Contexts;

public class OnionArchOrnegiDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
{

    public OnionArchOrnegiDbContext(DbContextOptions<OnionArchOrnegiDbContext> options) : base(options)
    {

    }

    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Product> Products { get; set; }




    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(OnionArchOrnegiDbContext).Assembly);
    }
}