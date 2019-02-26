using System.Threading;
using System.Threading.Tasks;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Core.Bus
{
    public interface IBus
    {
        Task SendCommand<T>(T theCommand) where T : Command;
        Task RaiseEvent<T>(T theEvent) where T : Event;
    }
}
