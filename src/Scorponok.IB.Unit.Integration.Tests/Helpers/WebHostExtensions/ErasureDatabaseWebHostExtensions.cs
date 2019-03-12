using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Scorponok.IB.Unit.Integration.Tests.Helpers.WebHostExtensions
{
    public static class ErasureDatabaseWebHostExtensions
    {
        public static IWebHost ErasureDatabase<TContext>(this IWebHost webHost,
            Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                context.Database
                    .EnsureDeleted();
            }

            return webHost;
        }
    }
}