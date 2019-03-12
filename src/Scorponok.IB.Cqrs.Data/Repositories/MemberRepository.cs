using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Domain.Models.Members;
using Scorponok.IB.Domain.Models.Members.IRepository;

namespace Scorponok.IB.Cqrs.Data.Repositories
{
	public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
		public MemberRepository(DataContext context) 
			: base(context)
		{
			
		}
	}
}