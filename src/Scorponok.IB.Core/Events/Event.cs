using System;

namespace Scorponok.IB.Core.Events
{
    public abstract class Event : Message
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
