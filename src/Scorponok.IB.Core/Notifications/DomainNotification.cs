using System;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int Version { get; private set; }

        public DomainNotification(string key, string value, int version = 1)
        {
            this.DomainNotificationId = Guid.NewGuid();
            this.Version = version;
            this.Key = key;
            this.Value = value;
        }

    }
}
