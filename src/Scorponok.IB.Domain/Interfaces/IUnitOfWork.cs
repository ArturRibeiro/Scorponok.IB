using System;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		CommandResult Commit();
	}
}