using Scorponok.IB.Core.Events;
using Scorponok.IB.Domain.Models.Organizacoes.EventHandlers.Events;

namespace Scorponok.IB.Domain.Models.Organizacoes.ICommandHandler
{
	public interface IOrganicaoCommandHandler : IHandler<NovaOrganizacaoEventCommand>
	{
		
	}
}