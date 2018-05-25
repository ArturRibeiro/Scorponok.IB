using System;
using System.Linq;
using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Core.Respositorys
{
	public interface IRespositoryBase<TEntity> /*IDisposable*/ where TEntity : Entity
	{
		void Add(TEntity obj);
		TEntity GetById(Guid id);
		IQueryable<TEntity> GetAll();
		void Update(TEntity obj);
		void Remove(Guid id);
		int SaveChanges();
	}
}