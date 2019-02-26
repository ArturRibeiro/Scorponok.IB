using System;
using MediatR;

namespace Scorponok.IB.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp
        {
            get;
            private set;
        }

        public Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
