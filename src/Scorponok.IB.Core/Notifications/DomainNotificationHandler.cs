using System.Collections.Generic;
using System.Linq;

namespace Scorponok.IB.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
			=> _notifications = new List<DomainNotification>();
        
        public IList<DomainNotification> GetNotifications()
			=> _notifications;

        public void Handle(DomainNotification message)
			=> _notifications.Add(message);

        public bool HasNotifications()
			=> _notifications.Any();
        
        public void Dispose()
			=> _notifications = new List<DomainNotification>();
        
    }
}
