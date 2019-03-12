using AutoMapper;
using Scorponok.IB.Domain.Models.Contributions.Commands;

namespace Scorponok.IB.Web.Api.Inputs.Profiles
{
    public class ContributionRegisterProfile : Profile
    {
        public ContributionRegisterProfile()
        {
            CreateMap<ValueMessageRequest, RegisterContributionCommand>();
        }
    }
}