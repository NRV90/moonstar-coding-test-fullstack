using BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackEnd.Api
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                using var context = scope.ServiceProvider.GetRequiredService<PostDbContext>();

                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
            return host;
        }
    }
}
