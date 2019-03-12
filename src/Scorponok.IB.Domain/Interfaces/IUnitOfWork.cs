using System;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Domain.Models.Churchs.IRepository;
using Scorponok.IB.Domain.Models.Contributions.IRepository;
using Scorponok.IB.Domain.Models.Members.IRepository;

namespace Scorponok.IB.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		CommandResult Commit();

	    IChurchRepository ChurchRepository { get; }
	    IMemberRepository MemberRepository { get; }
	    IContributionRepository ContributionRepository { get; }
    }
}