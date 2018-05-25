using Scorponok.IB.Cqrs.Pagamento.Data.Context;
using Scorponok.IB.Domain.Models.Churchs;
using Scorponok.IB.Domain.Models.Churchs.IRespository;

namespace Scorponok.IB.Cqrs.Pagamento.Data.Repositorys
{
	public class ChurchRepository : RepositoryBase<Church>, IChurchRepository
	{
		public ChurchRepository(DataContext context) 
			: base(context)
		{
			
		}
	}
}