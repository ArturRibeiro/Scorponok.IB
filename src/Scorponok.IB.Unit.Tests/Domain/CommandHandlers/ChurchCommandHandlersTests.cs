//using FluentAssertions;

using FluentAssertions;
using Moq;
using NUnit.Framework;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Models.Organizacoes;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;
using Scorponok.IB.Domain.Models.Organizacoes.IRespository;
using Scorponok.IB.Unit.Tests.Domain.Models.Organizacoes.Events;

namespace Scorponok.IB.Unit.Tests.Domain.CommandHandlers
{
	[TestFixture, Category("Domain/CommandHandlers/Church")]
	public class ChurchCommandHandlersTests
	{
		private readonly Mock<IUnitOfWork> _uow;
		private readonly Mock<IBus> _bus;
		private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notification;
		private readonly Mock<IChurchRepository> _mockChurchRepository;

		public ChurchCommandHandlersTests()
		{
			_uow = new Mock<IUnitOfWork>();
			_bus = new Mock<IBus>();
			_notification = new Mock<IDomainNotificationHandler<DomainNotification>>();
			_mockChurchRepository = new Mock<IChurchRepository>();
		}

		[Test]
		public void Must_register_a_church_successfully()
		{
			var commandHandler = new ChurchCommandHandlers(
				_uow.Object
				, _bus.Object
				, _notification.Object
				, _mockChurchRepository.Object);

			var argument = new RegisterChurchCommand("Richmond’s First Baptist Church", email: "Scorponok@scorponok.com", photo: "1.jpg", telephone: "123456789");

			ChurchRegisteredEvent churchRegisteredEvent = null;

			//Setup
			_uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));
			_bus.Setup(x => x.RaiseEvent(It.IsAny<ChurchRegisteredEvent>()))
				.Callback<ChurchRegisteredEvent>(x => { churchRegisteredEvent = x; });

			//Act's
			commandHandler.Handle(argument);

			//Assert's
			commandHandler.Commit().Should().BeTrue();
			churchRegisteredEvent.Should().NotBeNull();
			churchRegisteredEvent.Id.Should().NotBeEmpty();
			churchRegisteredEvent.Name.Should().Be(argument.Name);
			churchRegisteredEvent.Photo.Should().Be(argument.Photo);
			churchRegisteredEvent.Email.Should().Be(argument.Email);
			churchRegisteredEvent.DDD.Should().Be(argument.DDD);
			churchRegisteredEvent.Telephone.Should().Be(argument.Telephone);

			//Verify that methods were invocation
			_mockChurchRepository.Verify(x => x.Add(It.IsAny<Church>()), Times.Once);
			_bus.Verify(x => x.RaiseEvent(It.IsAny<DomainNotification>()), Times.Never());
			_uow.Verify(x => x.Commit(), Times.Exactly(2));
			_bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchRegisteredEvent>()), Times.Once);
		}

		//[Test]
		//public void Registering_church_with_parameter_null_should_fail()
		//{
		//	//Arrange
		//	var commandHandler = new ChurchCommandHandlers(
		//		_uow.Object
		//		, _bus.Object
		//		, _notification.Object);


		//	//Act's
		//	commandHandler.Handle(null);
		//}


	}
}