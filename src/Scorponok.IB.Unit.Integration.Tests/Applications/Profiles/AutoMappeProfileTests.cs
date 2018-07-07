using AutoMapper;
using NUnit.Framework;
using Scorponok.IB.Application.AutoMapper;

namespace Scorponok.IB.Unit.Integration.Tests.Applications.Profiles
{
    [TestFixture]
    public class AutoMappeProfileTests
    {
        [Test]
        public void MappingProfile_VerifyMappings()
        {
            var mappingProfile = AutoMapperConfig.RegisterMappings();

            var mapper = new Mapper(mappingProfile);

            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}