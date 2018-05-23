using System;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Organizacoes.Commands
{
	public class DeleteChurchCommand : Command
	{
		public Guid Id { get; }

		public DeleteChurchCommand(Guid id)
			=> Id = id;
		

		public override bool IsValid()
			=> true;
	}
}