using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Interfaces;
using Scorponok.IB.Domain.Models.Contributions;
using Scorponok.IB.Domain.Models.Contributions.Commands;
using Scorponok.IB.Domain.Models.Contributions.IRepository;
using Scorponok.IB.Domain.Models.Members;
using Scorponok.IB.Domain.Models.Members.IRepository;

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
            var member = _uow.MemberRepository.GetById(message.MemberId);

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