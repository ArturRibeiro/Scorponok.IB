using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Domain.Models.Churchs.Events;

namespace Scorponok.IB.Domain.EventHandlers
{
    public class ChurchEventHandlers : INotificationHandler<ChurchRegisteredEvent>
	    , INotificationHandler<ChurchUpdatedEvent>
	    , INotificationHandler<ChurchDeletedEvent>
    {
        public async Task Handle(ChurchRegisteredEvent notification, CancellationToken cancellationToken)
        {

        }

        public async Task Handle(ChurchUpdatedEvent notification, CancellationToken cancellationToken)
        {
            
        }

        public async Task Handle(ChurchDeletedEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}