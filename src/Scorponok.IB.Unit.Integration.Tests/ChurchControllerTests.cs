using System.Net;
using System.Runtime.CompilerServices;
using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Web.Api.Churchs.Views;

namespace Scorponok.IB.Unit.Integration.Tests
{
    [TestFixture]
	public class ChurchControllerTests
	{
        private const string ROUTE_REGISTER = "Church/register";

        [TestCase("scorponok", "scorponok@gmail.com", "scorponok.jpg", 21, 55, "27605555", "999999999")]
	    public void Register(string name, string email, string photo, byte prefix, byte region, string telephoneFixed, string mobileTelephone)
        {
            //Arrang's
            var requestMessage = new ChurchRegisteringMessageRequest()
            {
                Name = name,
                Email = email,
                Photo = photo,
                Prefix = prefix,
                Region = region,
                TelephoneFixed = telephoneFixed,
                MobileTelephone = mobileTelephone
            };

            //Act
            var response = BaseIntegrationTest.PostAsync(requestMessage, ROUTE_REGISTER);
            response.Wait();

            //Assert's
            response.Result.Should().NotBeNull();
            response.Result.IsSuccessStatusCode.Should().BeTrue();
            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Ignore("")]
	    public void Update_church()
	    {
            
	    }

	    [Ignore("")]
	    public void Deleted_church()
	    {

	    }
    }
}