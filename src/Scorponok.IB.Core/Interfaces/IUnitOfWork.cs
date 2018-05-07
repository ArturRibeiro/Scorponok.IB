using System;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Core.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		CommandResult Commit();
	}
}