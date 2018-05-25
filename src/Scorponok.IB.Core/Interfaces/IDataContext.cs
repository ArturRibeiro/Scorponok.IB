using System;
using Microsoft.EntityFrameworkCore;

namespace Scorponok.IB.Core.Interfaces
{
	public interface IDataContext : IDisposable
	{
		DbSet<T> dbSet<T>() where T : class; //This will be how you go about calling your models.
	}
}