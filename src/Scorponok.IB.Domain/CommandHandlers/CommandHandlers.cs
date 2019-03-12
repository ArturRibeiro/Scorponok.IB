using System;
using MediatR;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Interfaces;

namespace Scorponok.IB.Core.Commands
{
    public abstract class CommandHandler
	{
	    protected readonly IUnitOfWork _uow;
	    protected readonly IBus _bus;
	    private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IUnitOfWork uow, IBus bus, INotificationHandler<DomainNotification> notification)
		{
			_uow = uow;
			_bus = bus;
		    _notifications = (DomainNotificationHandler)notification;
        }

		protected void NotifyErrors(Command command)
		{
			foreach (var error in command.ValidationResult.Errors)
				_bus.RaiseEvent(DomainNotification.Factory.Create(error.PropertyName, error.ErrorMessage));
		}

		public bool Commit()
		{
			if (_notifications.HasNotifications()) return false;

            try
            {
                var commandResult = _uow.Commit();

                if (!commandResult.Success) _bus.RaiseEvent(DomainNotification.Factory.Create("Commit", "Ocorreu um erro ao  salvar os dados no banco."));

                return commandResult.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }

		}
	}
}