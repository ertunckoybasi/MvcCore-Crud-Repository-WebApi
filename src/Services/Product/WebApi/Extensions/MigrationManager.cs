using ProductSrv.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace WebApi.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            try
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                ApplicationDbContextSeed.SeedSampleDataAsync(dbContext).Wait();
            }
            catch (Exception ex)
            {

                //  throw;
            }
        }

        return host;
    }
}
