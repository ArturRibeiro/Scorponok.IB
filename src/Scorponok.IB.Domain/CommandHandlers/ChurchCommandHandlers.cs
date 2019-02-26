using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Domain.Models.Churchs;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Domain.Models.Churchs.Events;
using Scorponok.IB.Domain.Models.Churchs.IRepository;

namespace Scorponok.IB.Domain.CommandHandlers
{
    public class ChurchCommandHandlers : CommandHandler
        , IRequestHandler<RegisterChurchCommand>
        , IRequestHandler<UpdateChurchCommand>
        , IRequestHandler<DeleteChurchCommand>
    {
        private readonly IChurchRepository _churchRepository;

        public ChurchCommandHandlers(IUnitOfWork uow, IBus bus, INotificationHandler<DomainNotification> notification,
            IChurchRepository churchRepository)
            : base(uow, bus, notification)
            => _churchRepository = churchRepository;

        public async Task<Unit> Handle(RegisterChurchCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyErrors(message);
                return Unit.Value;
            }

            var church = CreateNewChurch(message);
            if (church.IsValid()) _churchRepository.Add(church);
            if (Commit()) await _bus.RaiseEvent(ChurchRegisteredEvent.Factory.Create(church.Id, church.Name, church.Photo, church.Email.Value, church.MobileTelephone.Prefix, church.MobileTelephone.Number));

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateChurchCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyErrors(message);
                return Unit.Value;
            }

            var church = UpdateChurch(message);
            if (church.IsValid()) _churchRepository.Update(church);
            if (Commit()) await _bus.RaiseEvent(ChurchUpdatedEvent.Factory.Create(church.Id, church.Name, church.Photo, church.Email.Value, church.MobileTelephone.Prefix, church.MobileTelephone.Number));

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteChurchCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyErrors(message);
                return Unit.Value;
            }

            _churchRepository.Remove(message.Id);
            if (Commit()) await _bus.RaiseEvent(ChurchDeletedEvent.Factory.Create(message.Id));

            return Unit.Value;
        }

        #region Private Methods
        private static Church CreateNewChurch(
            RegisterChurchCommand message)
                => Church.Factory.CreateNew
                    (
                        name: message.Name
                        , photo: message.Photo
                        , email: Email.Factory.CreateNew(message.Email)
                        , telephoneFixed: Telephone.Factory.CreateNew(55, 21, message.PhoneFixed)
                        , mobileTelephone: Telephone.Factory.CreateNew(55, 21, message.PhoneMobile)
                        , endereco: null
                    );

        private Church UpdateChurch(
            UpdateChurchCommand message)
            => _churchRepository.GetById(message.Id)
                .UpdateName(message.Name)
                .UpdatePhoto(message.Photo)
                .UpdateEmail(message.Email)
                .UpdateTelephone(message.PhoneMobile);

        #endregion
    }
}