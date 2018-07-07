using System.Collections.Generic;
using System.Linq;

namespace Scorponok.IB.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
			=> _notifications = new List<DomainNotification>();
        
        public virtual IList<DomainNotification> GetNotifications()
			=> _notifications;

        public void Handle(DomainNotification message)
			=> _notifications.Add(message);

        public virtual bool HasNotifications()
			=> GetNotifications().Any();
        
        public void Dispose()
			=> _notifications = new List<DomainNotification>();
        
    }
}
