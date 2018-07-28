using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Domain.Models.Churchs;
using Scorponok.IB.Domain.Models.Churchs.IRespository;

namespace Scorponok.IB.Cqrs.Data.Repositories
{
	public class ChurchRepository : RepositoryBase<Church>, IChurchRepository
	{
		public ChurchRepository(DataContext context) 
			: base(context)
		{
			
		}
	}
}