using System;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Domain.Models.Churchs.Events
{
    public class ChurchRegisteredEvent : Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Photo { get; private set; }
        public string Email { get; private set; }
        public byte DDD { get; private set; }
        public string Telephone { get; private set; }

        public static class Factory
        {
            public static ChurchRegisteredEvent Create(Guid id, string name, string photo, string email, byte ddd, string telephone)
                => new ChurchRegisteredEvent()
                {
                    Id = id,
                    Name = name,
                    Photo = photo,
                    Email = email,
                    DDD = ddd,
                    Telephone = telephone
                };
        }
    }

}
