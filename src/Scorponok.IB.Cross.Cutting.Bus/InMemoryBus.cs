using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Notifications;

namespace Scorponok.IB.Cross.Cutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore)
            => _eventStore = eventStore;

        public async Task RaiseEvent<T>(T theEvent) where T : Event
        {
            if (!theEvent.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(theEvent);

            Publish(theEvent);
        }

        public async Task SendCommand<T>(T theCommand) where T : Command => Publish(theCommand);

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IRequestHandler<T>));

            var handler = (IRequestHandler<T>)obj;

            handler.Handle(message, default(CancellationToken));
        }

    }
}
