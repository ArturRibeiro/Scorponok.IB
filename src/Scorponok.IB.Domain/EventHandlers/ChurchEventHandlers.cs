using Scorponok.IB.Core.Events;
using Scorponok.IB.Domain.Models.Churchs.Events;

namespace Scorponok.IB.Domain.EventHandlers
{
	public class ChurchEventHandlers : IHandler<ChurchRegisteredEvent>
	    , IHandler<ChurchUpdatedEvent>
    {
		public void Handle(ChurchRegisteredEvent message)
		{
			
		}

        public void Handle(ChurchUpdatedEvent message)
        {
            
        }
    }
}