using AutoMapper;
using Scorponok.IB.Application.Churchs.Profiles;

namespace Scorponok.IB.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ChurchRegisterProfile());
            });
        }
    }
}