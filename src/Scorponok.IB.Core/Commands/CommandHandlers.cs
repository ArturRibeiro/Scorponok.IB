using FluentValidation.Results;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;

namespace Scorponok.IB.Core.Commands
{
	public abstract class CommandHandler
	{
		protected readonly IUnitOfWork _uow;
		protected readonly IBus _bus;
		protected readonly IDomainNotificationHandler<DomainNotification> _notification;

	    protected CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification)
		{
			_uow = uow;
			_bus = bus;
			_notification = notification;
		}

		protected void NotifyErrors(Command command)
		{
			foreach (var error in command.ValidationResult.Errors)
				_bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
		}

		public bool Commit()
		{
			if (_notification.HasNotifications()) return false;

			var commandResult = _uow.Commit();

			if (!commandResult.Success) _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao  salvar os dados no banco."));

			return commandResult.Success;
		}
	}
}