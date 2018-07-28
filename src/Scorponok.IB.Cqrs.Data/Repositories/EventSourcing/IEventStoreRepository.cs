using System;
using System.Collections.Generic;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Cqrs.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}