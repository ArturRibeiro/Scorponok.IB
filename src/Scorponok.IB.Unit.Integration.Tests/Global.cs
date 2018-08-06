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

		    // Devemos configurar o caminho real do projeto direcionado
		    var appRootPath = @"E:\Projetos\Git\Scorponok\Scorponok.IB.Cqrs\src\Scorponok.IB.Web.Api\";

		    // define variáveis ​​de ambiente
		    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
		    Environment.SetEnvironmentVariable("REGISTRY_CONFIG_FILE", Path.Combine(appRootPath, "appsettings.json"));
		    //Environment.SetEnvironmentVariable("REGISTRY_DB_PASSWORD_SECRET_FILE", Path.Combine(appRootPath, "InsecureSecretFiles", "RegistryDbPassword.txt"));
		    Environment.SetEnvironmentVariable("REGISTRY_USE_DOCKER_SECRETS", "false");

		    var webHosting = new WebHostBuilder()
		        .UseEnvironment("Development")
		        .UseContentRoot(appRootPath)
		        .UseConfiguration(new ConfigurationBuilder()
		            .SetBasePath(appRootPath)
		            .AddJsonFile("appsettings.json")
		            .Build())
		        .UseStartup<Startup>();

		    BaseIntegrationTest.Server = new TestServer(webHosting);
        }

		//private void CreteDataBase()
		//{
		//	var dbContext = NativeInjectorBootStrapper.Container.GetService<DataContext>();
		//	dbContext.Database.EnsureDeleted();
		//	dbContext.Database.EnsureCreated();

		//	Console.WriteLine("Database created");
		//}

		[OneTimeTearDown]
		public void End()
		{
			Console.Write("TearDown");
		}
	}
}

	