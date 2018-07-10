using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.Respositorys;
using Scorponok.IB.Cqrs.Data.Context;

namespace Scorponok.IB.Cqrs.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRespositoryBase<TEntity> where TEntity : Entity
	{
		protected readonly DataContext _dataContext;
		protected readonly DbSet<TEntity> _dbSet;

		public RepositoryBase(DataContext context)
		{
			_dataContext = context;
			_dbSet = _dataContext.Set<TEntity>();
		}

		//public void Dispose()
		//{
		//	//20181029423354
		//	_dataContext.Dispose();
		//	GC.SuppressFinalize(this);
		//}

		public void Add(TEntity obj)
			=> _dbSet.Add(obj);
		
		public TEntity GetById(Guid id)
			=> _dbSet.Find(id);
		
		public IQueryable<TEntity> GetAll()
			=> _dbSet;

		public void Update(TEntity obj)
			=> _dbSet.Update(obj);

		public void Remove(Guid id)
			=> _dbSet.Remove(_dbSet.Find(id));

		public int SaveChanges()
			=> _dataContext.SaveChanges();
	}
}