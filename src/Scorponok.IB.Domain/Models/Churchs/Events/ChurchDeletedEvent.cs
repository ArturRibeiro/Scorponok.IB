using System;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Domain.Models.Churchs.Events
{
	public class ChurchDeletedEvent : Event
	{
		public Guid Id;

		public ChurchDeletedEvent(Guid id)
			=> Id = id;
	}
}