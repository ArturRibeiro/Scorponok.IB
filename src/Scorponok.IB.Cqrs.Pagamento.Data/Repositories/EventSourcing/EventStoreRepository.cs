using System;
using System.Collections.Generic;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Cqrs.Data.Context;

namespace Scorponok.IB.Cqrs.Data.Repositories.EventSourcing
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreContext _eventStoreContext;

        public EventStoreRepository(EventStoreContext eventStoreContext)
        {
            _eventStoreContext = eventStoreContext;
        }

        public void Store(StoredEvent theEvent)
        {
            _eventStoreContext.StoredEvent.Add(theEvent);
            _eventStoreContext.SaveChanges();
        }

        public void Dispose()
        {
            _eventStoreContext.Dispose();
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}