using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Scorponok.IB.Cqrs.Pagamento.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Scorponok.IB.Unit.Integration.Tests
{

	[SetUpFixture, Category("Global")]
	public class Global
	{
		[OneTimeSetUp]
		public void SetUp()
		{
			Console.Write("SetUp");

			Ioc.Setup();

			CreteDataBase();
		}

		private void CreteDataBase()
		{
			var dbContext = Ioc.Provider.GetService<DataContext>();
			dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();

			Console.WriteLine("Database created");
		}

		[OneTimeTearDown]
		public void End()
		{
			Console.Write("TearDown");
		}
	}
}

	