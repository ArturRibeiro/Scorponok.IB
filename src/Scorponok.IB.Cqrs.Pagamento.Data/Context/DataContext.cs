using System;
using Microsoft.EntityFrameworkCore;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Cqrs.Pagamento.Data.Mappings;

namespace Scorponok.IB.Cqrs.Pagamento.Data.Context
{
	public class DataContext : DbContext, IDataContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ChurchMap());

			base.OnModelCreating(modelBuilder);
		}

		public void Dispose()
		{
			
		}

		public DbSet<T> dbSet<T>() where T : class
		{
			throw new NotImplementedException();
		}
	}
}