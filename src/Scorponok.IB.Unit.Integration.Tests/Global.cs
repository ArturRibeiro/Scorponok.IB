using System;
using System.Data.Entity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Web.Api;

namespace Scorponok.IB.Unit.Integration.Tests
{

    [SetUpFixture, Category("Global")]
    public class Global
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Console.Write("SetUp");

            var pathServices = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Scorponok.IB.Web.Api"));
            if (!Directory.Exists(pathServices)) throw new DirectoryNotFoundException($"{pathServices}");

            //Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            //Environment.SetEnvironmentVariable("REGISTRY_CONFIG_FILE", Path.Combine(pathServices, "appsettings.json"));
            //Environment.SetEnvironmentVariable("REGISTRY_DB_PASSWORD_SECRET_FILE", Path.Combine(appRootPath, "InsecureSecretFiles", "RegistryDbPassword.txt"));
            //Environment.SetEnvironmentVariable("REGISTRY_USE_DOCKER_SECRETS", "false");

            var webHosting = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(pathServices)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(pathServices)
                    .AddJsonFile("appsettings.json")
                    .Build())
                .UseStartup<Startup>();

            BaseIntegrationTest.Server = new TestServer(webHosting);
        }

        [OneTimeTearDown]
        public void End()
        {
            Console.Write("TearDown");
        }
    }
}

