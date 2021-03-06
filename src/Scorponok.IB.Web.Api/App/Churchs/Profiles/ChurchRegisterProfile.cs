﻿using AutoMapper;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Web.Api.App.Churchs.Views;

namespace Scorponok.IB.Web.Api.App.Churchs.Profiles
{
    public class ChurchRegisterProfile : Profile
    {
        public ChurchRegisterProfile()
        {
            CreateMap<ChurchRegisteringMessageRequest, RegisterChurchCommand>()
                .ForMember(dest => dest.Timestamp, origin => origin.Ignore())
                .ForMember(dest => dest.ValidationResult, origin => origin.Ignore())
                .ForMember(dest => dest.MessageType, origin => origin.Ignore())
                .ForMember(dest => dest.AggregateId, origin => origin.Ignore())
                .ForMember(dest => dest.CellPhone, origin => origin.MapFrom(x => x.MobileTelephone))
                .ForMember(dest => dest.HomePhone, origin => origin.MapFrom(x => x.TelephoneFixed));
                //.ConstructUsing(x => new RegisterChurchCommand(x.Name, x.Photo, x.Email, 55, 21, x.MobileTelephone));
        }

    }
}