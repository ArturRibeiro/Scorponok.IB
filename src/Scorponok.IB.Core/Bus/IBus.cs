using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
