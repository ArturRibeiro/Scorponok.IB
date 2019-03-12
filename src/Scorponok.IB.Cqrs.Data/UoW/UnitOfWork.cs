using Scorponok.IB.Core.Commands;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Cqrs.Data.Repositories;
using Scorponok.IB.Domain.Interfaces;
using Scorponok.IB.Domain.Models.Churchs.IRepository;
using Scorponok.IB.Domain.Models.Contributions.IRepository;
using Scorponok.IB.Domain.Models.Members.IRepository;

namespace Scorponok.IB.Cqrs.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;

		public UnitOfWork(DataContext context)
			=> _context = context;

	    public IChurchRepository ChurchRepository => new ChurchRepository(_context);
	    public IMemberRepository MemberRepository => new MemberRepository(_context);
	    public IContributionRepository ContributionRepository => new ContributionRepository(_context);

        public CommandResult Commit()
		{
			var rowsAffected = _context.SaveChanges();
			return new CommandResult(rowsAffected > 0);
		}

		public void Dispose()
			=> _context.Dispose();
	}
}