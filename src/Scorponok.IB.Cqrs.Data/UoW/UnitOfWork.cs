using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.Respositorys;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Cqrs.Data.Repositories;

namespace Scorponok.IB.Cqrs.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;

		public UnitOfWork(DataContext context)
			=> _context = context;

	    public IRespositoryBase<TEntity> Repository<TEntity>() where TEntity : Entity
	    {
            return new RepositoryBase<TEntity>(_context);
	    }

        public CommandResult Commit()
		{
			var rowsAffected = _context.SaveChanges();
			return new CommandResult(rowsAffected > 0);
		}

		public void Dispose()
			=> _context.Dispose();
	}
}