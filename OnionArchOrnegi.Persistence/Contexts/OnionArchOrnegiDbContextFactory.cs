using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnionArchOrnegi.Persistence.Contexts;

public class OnionArchOrnegiDbContextFactory : IDesignTimeDbContextFactory<OnionArchOrnegiDbContext>
{
    public OnionArchOrnegiDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
        var optionsBuilder = new DbContextOptionsBuilder<OnionArchOrnegiDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        return new OnionArchOrnegiDbContext(optionsBuilder.Options);
    }
}