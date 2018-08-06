using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Cqrs.Data.Context;

namespace Scorponok.IB.Unit.Integration.Tests
{

	[SetUpFixture, Category("Global")]
	public class Global
	{
		[OneTimeSetUp]
		public void SetUp()
		{
			Console.Write("SetUp");

			NativeInjectorBootStrapper.Setup();

			//CreteDataBase();
		}

		private void CreteDataBase()
		{
			var dbContext = NativeInjectorBootStrapper.Container.GetService<DataContext>();
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

	