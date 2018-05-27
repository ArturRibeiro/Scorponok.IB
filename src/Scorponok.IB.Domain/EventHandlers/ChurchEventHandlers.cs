using Scorponok.IB.Core.Events;
using Scorponok.IB.Domain.Models.Churchs.Events;

namespace Scorponok.IB.Domain.EventHandlers
{
	public class ChurchEventHandlers : IHandler<ChurchRegisteredEvent>
	{
		public void Handle(ChurchRegisteredEvent message)
		{
			
		}
	}
}