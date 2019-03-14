using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Interfaces;
using Scorponok.IB.Domain.Models.Contributions.Events;

namespace Scorponok.IB.Domain.EventHandlers
{
    public class ContributionEventHandlers : INotificationHandler<ContributionRegisterNameMemberEvent>
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler<DomainNotification> _notification;

        public ContributionEventHandlers(IUnitOfWork uow, INotificationHandler<DomainNotification> notification)
        {
            _uow = uow;
            _notification = notification;
        }

        public async Task Handle(ContributionRegisterNameMemberEvent message, CancellationToken cancellationToken)
        {
            _uow.MemberRepository.Add(message.Member);
        }
    }
}