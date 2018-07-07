using System;

namespace Scorponok.IB.Core.Events
{
    public class StoredEvent : Event
    {

        protected StoredEvent() { }

        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Data { get; private set; } = null;

        public string User { get; private set; } = null;
    }
}