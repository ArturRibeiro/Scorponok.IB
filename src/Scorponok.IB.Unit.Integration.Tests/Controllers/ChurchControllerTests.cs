using NUnit.Framework;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Web.Api.Churchs.Views;
using Scorponok.IB.Web.Api.Controllers;

namespace Scorponok.IB.Unit.Integration.Tests.Controllers
{
	[TestFixture]
	public class ChurchControllerTests
	{
        [Test]
	    public void Register()
        {
            var controller = NativeInjectorBootStrapper.GetInstance<ChurchController>() as ChurchController;

            var result = controller.Register(new ChurchRegisteringMessageRequest()
            {
                Name = "Artur Araújo",
                Email = "xxxx@gmail.com",
                Photo = "name.jpg",
                Prefix = 21,
                Region = 55,
                TelephoneFixed = "27605555",
                MobileTelephone = "999999999"
            });

            

        }
	}
}