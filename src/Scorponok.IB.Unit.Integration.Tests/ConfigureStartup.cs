using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Unit.Integration.Tests.Helpers;
using Scorponok.IB.Unit.Integration.Tests.Helpers.WebHostExtensions;
using Scorponok.IB.Web.Api;

namespace Scorponok.IB.Unit.Integration.Tests
{
    public static class ConfigureStartup
    {
        public static TestServer CreateServer()
        {
            var pathServices = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Scorponok.IB.Web.Api"));
            if (!Directory.Exists(pathServices)) throw new DirectoryNotFoundException($"{pathServices}");

            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("IntegrationTest")
                .UseContentRoot(pathServices)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(pathServices)
                    .Build())
                .UseStartup<Startup>();

            var testServer = new TestServer(webHostBuilder);
            testServer.Host
                .ErasureDatabase<DataContext>((context, services) => { })
                .MigrateDbContext<DataContext>((context, services) =>
                {
                    //context.Database.ExecuteSqlCommand(..scripts);
                    var env = services.GetService<IHostingEnvironment>();
                    var dataContextSeed = new Seed();
                    dataContextSeed.SeedAsync(context, env).Wait();
                });

            return testServer;
        }
    }
}