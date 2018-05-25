using System;
using NUnit.Framework;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Models.Churchs.IRespository;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Churchs.Commands;

namespace Scorponok.IB.Unit.Integration.Tests.CommandHandlers
{
	[TestFixture, Category("Domain/CommandHandlers/Church")]
	public class ChurchCommandHandlersTests //: BaseIntegrationTest
	{
		[Test]
		public void Registing_church_with_success()
		{
			var bus = Ioc.Provider.GetService<IBus>();

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
		}
	}
}