using System.Collections.Generic;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();

        IList<T> GetNotifications();
    }
}
