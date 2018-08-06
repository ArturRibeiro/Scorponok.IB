using NUnit.Framework;
using Scorponok.IB.Core.Bus;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Domain.Models.Churchs.Events;

namespace Scorponok.IB.Unit.Integration.Tests.CommandHandlers
{
	[TestFixture, Category("Domain/CommandHandlers/Church")]
	public class ChurchCommandHandlersTests //: BaseIntegrationTest
	{
		[Test]
		public void Registing_church_with_success()
		{
			var bus = NativeInjectorBootStrapper.Container.GetService<IBus>();

			var registerChurchCommand = new RegisterChurchCommand
				(
					name: "Trinity Church Wall Street", 
					photo: "00000000001.jpg", 
					email: "contact@church.com", 
					region: 55, 
					prefix: 21, 
					number: "987413988"
				);

			bus.SendCommand(registerChurchCommand);

		    var test = NativeInjectorBootStrapper.Container.GetService<IHandler<ChurchRegisteredEvent>>();
        }
	}
}