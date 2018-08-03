using System;
using AutoMapper;
using Scorponok.IB.Application.Churchs.Interfaces;
using Scorponok.IB.Application.Churchs.Views;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Domain.Models.Churchs.Commands;

namespace Scorponok.IB.Application.Churchs
{
    public class ChurchApplication : IChurchApplication
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ChurchApplication(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        public void RegisterChurch(RegisterChurchViewModel view)
        {
            var command = _mapper.Map<RegisterChurchCommand>(view);
            _bus.SendCommand(command);
        }

        public void DeletedChurch(ChurchDeletedViewModel view)
            => _bus.SendCommand(DeleteRegisterChurch(view));

        public void UpdatedChurch(ChurchUpdatedViewModel view)
            => _bus.SendCommand(UpdateRegisterChurch(view));

        private DeleteChurchCommand DeleteRegisterChurch(ChurchDeletedViewModel view)
            => _mapper.Map<DeleteChurchCommand>(view);

        private RegisterChurchCommand UpdateRegisterChurch(ChurchUpdatedViewModel view)
            => _mapper.Map<RegisterChurchCommand>(view);

        public void Dispose() => GC.SuppressFinalize(this);
    }
}