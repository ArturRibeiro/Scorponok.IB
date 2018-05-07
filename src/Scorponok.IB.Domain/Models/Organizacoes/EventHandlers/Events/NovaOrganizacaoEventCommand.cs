using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Domain.Models.Organizacoes.EventHandlers.Events
{
	public class NovaOrganizacaoEventCommand : Event
	{
		public string Nome { get; private set; }
		public string Foto { get; private set; }
		public string Email { get; private set; }
		public string DDD { get; private set; }
		public string Telefone { get; private set; }

		public NovaOrganizacaoEventCommand(string nome, string foto, string email, string ddd, string telefone)
		{
			Nome = nome;
			Foto = foto;
			Email = email;
			DDD = ddd;
			Telefone = telefone;
		}
	}
}