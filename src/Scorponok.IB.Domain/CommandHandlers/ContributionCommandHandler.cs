using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Interfaces;
using Scorponok.IB.Domain.Models.Contributions;
using Scorponok.IB.Domain.Models.Contributions.Commands;
using Scorponok.IB.Domain.Models.Contributions.Events;
using Scorponok.IB.Domain.Models.Contributions.IRepository;
using Scorponok.IB.Domain.Models.Members;

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
            var member = Member.Factory.Create(message.Name, message.MemberId);
            await _bus.RaiseEvent(ContributionRegisterNameMemberEvent.Factory.Create(member));

            var contribution = Contribution.Factory.Create(member
                , message.DeliveryDate
                , message.Value
                , (TypeContribution)message.TypeContribution);

            _memberRepository.Add(contribution);

            Commit();

            return Unit.Value;
        }
    }
}