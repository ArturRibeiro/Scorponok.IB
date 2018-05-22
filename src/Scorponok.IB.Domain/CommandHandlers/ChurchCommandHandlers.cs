using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;

namespace Scorponok.IB.Domain.CommandHandlers
{
	public class ChurchCommandHandlers : CommandHandler
		, IHandler<RegisterChurchCommand>
		, IHandler<UpdateChurchCommand>
	{

		public ChurchCommandHandlers(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification) 
			: base(uow, bus, notification)
		{
		}

		public void Handle(RegisterChurchCommand message)
		{
			//if (message == null) throw new ArgumentNullException($"Argumento: {nameof(message)} inválido");

			//var email = Email.Factory.CreateNew(message.Email);
			//var telefone = Telephone.Factory.CreateNew(message.DDD, message.Telefone);

			//var cherch = Church.Factory.CreateNew(
			//	name: message.Nome
			//	, photo: message.Foto
			//	, email: email
			//	, telephone: telefone
			//	, endereco: null);

			//if (cherch.IsValid())
			//	_organizacaoRepository.Add(cherch);

			//if (Commit())
			//{

			//}
		}

		public void Handle(UpdateChurchCommand message)
		{
			
		}



	}
}