using Newtonsoft.Json;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Cqrs.Data.Repositories.EventSourcing;
using Scorponok.IB.Domain.Models.Users.Interfaces;

namespace Scorponok.IB.Cqrs.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public EventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Name);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}