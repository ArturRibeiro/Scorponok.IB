using AutoMapper;
using Scorponok.IB.Application.Churchs.Views;
using Scorponok.IB.Domain.Models.Churchs.Commands;

namespace Scorponok.IB.Application.Churchs.Profiles
{
    public class ChurchRegisterProfile : Profile
    {
        public ChurchRegisterProfile()
        {
            CreateMap<RegisterChurchViewModel, RegisterChurchCommand>()
                .ForMember(dest => dest.Timestamp, origem => origem.Ignore())
                .ForMember(dest => dest.ValidationResult, origem => origem.Ignore())
                .ForMember(dest => dest.MessageType, origem => origem.Ignore())
                .ForMember(dest => dest.AggregateId, origem => origem.Ignore())
                .ForMember(dest => dest.Telephone, origem => origem.MapFrom(x => x.TelephoneFixed))
                .ConstructUsing(x => new RegisterChurchCommand(x.Name, x.Photo, x.Email, 55, 21, x.MobileTelephone));
        }

    }
}