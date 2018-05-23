using System;
using System.Runtime.InteropServices;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Domain.Models.Organizacoes;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;
using Scorponok.IB.Domain.Models.Organizacoes.Events;
using Scorponok.IB.Domain.Models.Organizacoes.IRespository;

namespace Scorponok.IB.Domain.CommandHandlers
{
	public class ChurchCommandHandlers : CommandHandler
		, IHandler<RegisterChurchCommand>
		, IHandler<UpdateChurchCommand>
		, IHandler<DeleteChurchCommand>
	{
		private readonly IChurchRepository _churchRepository;

		public ChurchCommandHandlers(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification,
			IChurchRepository churchRepository)
			: base(uow, bus, notification)
			=> _churchRepository = churchRepository;

		public void Handle(RegisterChurchCommand message)
		{
			if (!message.IsValid())
			{
				NotifyErrors(message);
				return;
			}

			var church = CreateNewChurch(message);
			if (church.IsValid()) _churchRepository.Add(church);
			if (Commit()) _bus.RaiseEvent(new ChurchRegisteredEvent(church.Id, church.Name, church.Photo, church.Email.Value, church.Telephone.DDD, church.Telephone.Numero));
		}

		public void Handle(UpdateChurchCommand message)
		{
			if (!message.IsValid())
			{
				NotifyErrors(message);
				return;
			}

			var church = UpdateChurch(message);
			if (church.IsValid()) _churchRepository.Update(church);
			if (Commit()) _bus.RaiseEvent(new ChurchUpdatedEvent(church.Id, church.Name, church.Photo, church.Email.Value, church.Telephone.DDD, church.Telephone.Numero));
		}

		public void Handle(DeleteChurchCommand message)
		{
			if (!message.IsValid())
			{
				NotifyErrors(message);
				return;
			}

			_churchRepository.Remove(message.Id);
			if (Commit()) _bus.RaiseEvent(new ChurchDeletedEvent(message.Id));
		}

		private static Church CreateNewChurch(
			RegisterChurchCommand message)
			=> Church.Factory.CreateNew
				(
					name: message.Name
					, photo: message.Photo
					, email: Email.Factory.CreateNew(message.Email)
					, telephone: Telephone.Factory.CreateNew(message.DDD, message.Telephone)
					, endereco: null
				);

		private Church UpdateChurch(
			UpdateChurchCommand message)
			=> _churchRepository.GetById(message.Id)
				.UpdateName(message.Name)
				.UpdatePhoto(message.Photo)
				.UpdateEmail(message.Email)
				.UpdateTelephone(message.Telephone);
	}
}