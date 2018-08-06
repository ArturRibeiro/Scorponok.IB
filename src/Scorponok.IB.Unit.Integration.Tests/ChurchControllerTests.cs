using NUnit.Framework;
using Scorponok.IB.Web.Api.Churchs.Views;

namespace Scorponok.IB.Unit.Integration.Tests
{
    [TestFixture]
	public class ChurchControllerTests
	{
        [TestCase("scorponok", "scorponok@gmail.com", "scorponok.jpg", 21, 55, "27605555", "999999999")]
	    public void Register(string name, string email, string photo, byte prefix, byte region, string telephoneFixed, string mobileTelephone)
        {
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

            var response = BaseIntegrationTest.PostAsync(requestMessage, "Church/register");
            response.Wait();
            

        }
	}
}