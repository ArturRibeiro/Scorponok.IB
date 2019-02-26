using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Scorponok.IB.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
            => _notifications = new List<DomainNotification>();

        public virtual IList<DomainNotification> GetNotifications()
            => _notifications;

        public virtual async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
            => _notifications.Add(notification);

        public virtual bool HasNotifications()
            => GetNotifications().Any();

        public void Dispose()
            => _notifications = new List<DomainNotification>();


    }
}
