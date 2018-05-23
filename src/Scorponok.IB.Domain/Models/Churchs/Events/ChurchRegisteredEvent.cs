using System;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Domain.Models.Churchs.Events
{
	public class ChurchRegisteredEvent : Event
	{
		public Guid Id;
		public string Name;
		public string Photo;
		public string Email;
		public byte DDD;
		public string Telephone;

		public ChurchRegisteredEvent(Guid id, string name, string photo, string email, byte ddd, string telephone)
		{
			Id = id;
			Name = name;
			Photo = photo;
			Email = email;
			DDD = ddd;
			Telephone = telephone;
		}
		
	}
}