using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Contributions.Commands;
using Scorponok.IB.Domain.Models.Contributions.IRepository;

namespace Scorponok.IB.Domain.CommandHandlers
{
    public class ContributionCommandHandler : CommandHandler
        , IRequestHandler<RegisterContributionCommand>
    {
        private readonly IContributionRepository _memberRepository;

        public ContributionCommandHandler(IUnitOfWork uow, IBus bus, INotificationHandler<DomainNotification> notification,
            IContributionRepository memberRepository)
            : base(uow, bus, notification)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Unit> Handle(RegisterContributionCommand message, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}