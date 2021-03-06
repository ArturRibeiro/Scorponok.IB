﻿using AutoMapper;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Web.Api.App.Churchs.Views;

namespace Scorponok.IB.Web.Api.App.Churchs.Profiles
{
    public class ChurchUpdatedProfile : Profile
    {
        public ChurchUpdatedProfile()
        {
            CreateMap<ChurchUpdatedMessageRequest, UpdateChurchCommand>();

        }
    }
}
