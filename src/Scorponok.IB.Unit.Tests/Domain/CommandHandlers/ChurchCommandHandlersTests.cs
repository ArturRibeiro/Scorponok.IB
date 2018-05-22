//using FluentAssertions;

using FluentAssertions;
using Moq;
using NUnit.Framework;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;
using Scorponok.IB.Domain.Models.Organizacoes.IRespository;

namespace Scorponok.IB.Unit.Tests.Domain.CommandHandlers
{
	[TestFixture, Category("Domain/CommandHandlers/Church")]
	public class ChurchCommandHandlersTests
	{
		private readonly Mock<IUnitOfWork> _uow;
		private readonly Mock<IBus> _bus;
		private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notification;
		private readonly Mock<IChurchRepository> _mockOrganizacaoRepository;

		public ChurchCommandHandlersTests()
		{
			_uow = new Mock<IUnitOfWork>();
			_bus = new Mock<IBus>();
			_notification = new Mock<IDomainNotificationHandler<DomainNotification>>();
			_mockOrganizacaoRepository = new Mock<IChurchRepository>();
		}

		[Test]
		public void Must_register_a_church_successfully()
		{
			var commandHandler = new ChurchCommandHandlers(
				_uow.Object
				, _bus.Object
				, _notification.Object);

			var argument = new RegisterChurchCommand("1", email: "Scorponok@scorponok.com", photo: "..", telephone: "2198741333");

			//Setup
			_uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));

			//Act's
			commandHandler.Handle(argument);

			//Assert's
			commandHandler.Commit().Should().BeTrue();
		}


	}
}