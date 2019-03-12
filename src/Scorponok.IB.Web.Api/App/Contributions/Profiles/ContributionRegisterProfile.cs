using AutoMapper;
using Scorponok.IB.Domain.Models.Contributions.Commands;

namespace Scorponok.IB.Web.Api.App.Contributions.Profiles
{
    public class ContributionRegisterProfile : Profile
    {
        public ContributionRegisterProfile()
        {
            CreateMap<ValueMessageRequest, RegisterContributionCommand>();
        }
    }
}