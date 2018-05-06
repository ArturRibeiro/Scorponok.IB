using System;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp
        {
            get;
            private set;
        }

        public Command()
        {
            this.Timestamp = new DateTime();
        }
    }
}
