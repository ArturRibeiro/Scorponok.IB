using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Domain.Models.Contributions;
using Scorponok.IB.Domain.Models.Contributions.IRepository;

namespace Scorponok.IB.Cqrs.Data.Repositories
{
    public class ContributionRepository : RepositoryBase<Contribution>, IContributionRepository
    {
        public ContributionRepository(DataContext context) : base(context)
        {
        }
    }
}