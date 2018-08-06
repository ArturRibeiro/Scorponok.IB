using System;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.Respositorys;

namespace Scorponok.IB.Core.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		CommandResult Commit();

	    IRespositoryBase<TEntity> Repository<TEntity>() where TEntity : Entity;
	}
}