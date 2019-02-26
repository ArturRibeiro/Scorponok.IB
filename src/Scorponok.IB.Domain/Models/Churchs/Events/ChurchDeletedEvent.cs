using System;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Domain.Models.Churchs.Events
{
    public class ChurchDeletedEvent : Event
    {
        public Guid Id { get; private set; }

        public static class Factory
        {
            public static ChurchDeletedEvent Create(Guid id) 
                => new ChurchDeletedEvent() { Id = id };
        }
    }
}