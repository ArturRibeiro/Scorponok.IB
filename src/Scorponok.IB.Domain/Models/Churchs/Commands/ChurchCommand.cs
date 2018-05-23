using System;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public abstract class ChurchCommand : Command
	{
		public Guid Id { get; protected set; }
		public string Name { get; protected set; }
		public string Photo { get; protected set; }
		public string Email { get; protected set; }
		public byte DDD { get; protected set; }
		public string Telephone { get; protected set; }


		public abstract override bool IsValid();
	}
}