using Scorponok.IB.Core.Events;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;

namespace Scorponok.IB.Domain.CommandHandlers
{
	public class ChurchCommandHandlers : BaseCommandHandlers
		, IHandler<RegisterChurchCommand>
		, IHandler<UpdateChurchCommand>
	{
		public void Handle(RegisterChurchCommand message)
		{
			
		}

		public void Handle(UpdateChurchCommand message)
		{
			
		}


	}
}