using System;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Domain.Models.Organizacoes.EventHandlers.Events;
using Scorponok.IB.Domain.Models.Organizacoes.ICommandHandler;
using Scorponok.IB.Domain.Models.Organizacoes.IRespository;

namespace Scorponok.IB.Domain.Models.Organizacoes.CommandHandlers
{
	public class OrganicaoCommandHandler : CommandHandler, IOrganicaoCommandHandler
	{
		private readonly IOrganizacaoRepository _organizacaoRepository;

		public OrganicaoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification, IOrganizacaoRepository organizacaoRepository)
			: base(uow, bus, notification)
		{
			_organizacaoRepository = organizacaoRepository;
		}

		public void Handle(NovaOrganizacaoEventCommand message)
		{
			if (message == null) throw new ArgumentNullException($"Argumento: {nameof(message)} inválido");

			var email = Email.Factory.CreateNew(message.Email);
			var telefone = Telefone.Factory.CreateNew(message.DDD, message.Telefone);

			var organizacao = Igreja.Factory.CreateNew(
				nome: message.Nome
				, foto: message.Foto
				, email: email
				, telefone: telefone
				, endereco: null);

			if (organizacao.IsValid())
				_organizacaoRepository.Add(organizacao);

			if (Commit())
			{

			}
		}
	}
}