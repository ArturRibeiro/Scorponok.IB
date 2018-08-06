using AutoMapper;
using Scorponok.IB.Web.Api.Churchs.Profiles;

namespace Scorponok.IB.Web.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ChurchRegisterProfile());
                cfg.AddProfile(new ChurchUpdatedProfile());
            });
        }
    }
}