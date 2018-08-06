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

		    Func<string> GetPathWebApi = () =>
		    {
		        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		        var start = baseDirectory.LastIndexOf(@"Scorponok.IB.Cqrs", StringComparison.Ordinal);
		        var path = $"{AppDomain.CurrentDomain.BaseDirectory.Remove(start)}Scorponok.IB.Cqrs\\src\\Scorponok.IB.Web.Api";

		        if (!Directory.Exists(path)) throw new DirectoryNotFoundException($"{path}");

		        return path;
            };


		    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
		    Environment.SetEnvironmentVariable("REGISTRY_CONFIG_FILE", Path.Combine(GetPathWebApi(), "appsettings.json"));
		    //Environment.SetEnvironmentVariable("REGISTRY_DB_PASSWORD_SECRET_FILE", Path.Combine(appRootPath, "InsecureSecretFiles", "RegistryDbPassword.txt"));
		    Environment.SetEnvironmentVariable("REGISTRY_USE_DOCKER_SECRETS", "false");

		    var webHosting = new WebHostBuilder()
		        .UseEnvironment("Development")
		        .UseContentRoot(GetPathWebApi())
		        .UseConfiguration(new ConfigurationBuilder()
		            .SetBasePath(GetPathWebApi())
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

	