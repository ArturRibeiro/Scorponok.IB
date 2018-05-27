using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Cqrs.Pagamento.Data.Context;

namespace Scorponok.IB.Cqrs.Pagamento.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;

		public UnitOfWork(DataContext context)
			=> _context = context;

		public CommandResult Commit()
		{
			var rowsAffected = _context.SaveChanges();
			return new CommandResult(rowsAffected > 0);
		}

		public void Dispose()
			=> _context.Dispose();
	}
}