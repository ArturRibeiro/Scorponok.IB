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
		public void Registing()
		{
			var bus = Ioc.Provider.GetService<IBus>();

			var registerChurchCommand = new RegisterChurchCommand("Trinity Church Wall Street"
				, "00000000001.jpg"
				, "contact@church.com"
				, 55
				, 21
				, "987413988");

			bus.SendCommand(registerChurchCommand);
		}
	}
}