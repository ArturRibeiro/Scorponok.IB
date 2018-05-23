//using FluentAssertions;

using System;
using FizzWare.NBuilder;
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
using Scorponok.IB.Domain.Models.Organizacoes.Events;
using Scorponok.IB.Domain.Models.Organizacoes.IRespository;

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
		public void Registering_church_successfully()
		{
			var argument = new RegisterChurchCommand("Richmond’s First Baptist Church", email: "Scorponok@scorponok.com", photo: "1.jpg", telephone: "123456789");

			ChurchRegisteredEvent churchRegisteredEvent = null;
			Church church = null;

			//Setup
			_uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));
			_bus.Setup(x => x.RaiseEvent(It.IsAny<ChurchRegisteredEvent>()))
				.Callback<ChurchRegisteredEvent>(x => { churchRegisteredEvent = x; });

			//Act's
			var commandHandler = new ChurchCommandHandlers(
				_uow.Object, _bus.Object
				, _notification.Object, _mockChurchRepository.Object);
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
			_uow.Verify(x => x.Commit());
			_bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchRegisteredEvent>()), Times.Once);
		}

		[Test]
		public void Updating_church_successfully()
		{
			//Arrange's
			var argument = new UpdateChurchCommand(id: Guid.NewGuid()
				, name: "Richmond’s First Baptist Church"
				, email: "Scorponok@scorponok.com"
				, photo: "1.jpg"
				, telephone: "123456789");

			ChurchUpdatedEvent churchUpdatedEvent = null;
			Church church = null;

			//Setup
			_uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));
			_mockChurchRepository.Setup(x => x.GetById(argument.Id))
				.Returns(Builder<Church>
					.CreateNew()
				.Build);
			_bus.Setup(x => x.RaiseEvent(It.IsAny<ChurchUpdatedEvent>()))
				.Callback<ChurchUpdatedEvent>(x => { churchUpdatedEvent = x; });

			//Act's
			var commandHandler = new ChurchCommandHandlers(_uow.Object, _bus.Object
				, _notification.Object, _mockChurchRepository.Object);
			commandHandler.Handle(argument);

			//Assert's
			commandHandler.Commit().Should().BeTrue();
			churchUpdatedEvent.Should().NotBeNull();
			churchUpdatedEvent.Id.Should().NotBeEmpty();
			churchUpdatedEvent.Name.Should().Be(argument.Name);
			churchUpdatedEvent.Photo.Should().Be(argument.Photo);
			churchUpdatedEvent.Email.Should().Be(argument.Email);
			churchUpdatedEvent.DDD.Should().Be(argument.DDD);
			churchUpdatedEvent.Telephone.Should().Be(argument.Telephone);

			//Verify that methods were invocation
			_mockChurchRepository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
			_mockChurchRepository.Verify(x => x.Update(It.IsAny<Church>()), Times.Once);
			_bus.Verify(x => x.RaiseEvent(It.IsAny<DomainNotification>()), Times.Never());
			_uow.Verify(x => x.Commit());
			_bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchUpdatedEvent>()), Times.Once);
		}

		[Test]
		public void Deleting_church_successfully()
		{
			//Arrange's
			var argument = new DeleteChurchCommand(id: Guid.NewGuid());

			ChurchDeletedEvent churchDeletedEvent = null;
			Church church = null;

			//Setup
			_uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));
			_bus.Setup(x => x.RaiseEvent(It.IsAny<ChurchDeletedEvent>()))
				.Callback<ChurchDeletedEvent>(x => { churchDeletedEvent = x; });

			//Act's
			var commandHandler = new ChurchCommandHandlers(_uow.Object, _bus.Object
				, _notification.Object, _mockChurchRepository.Object);
			commandHandler.Handle(argument);

			//Assert's
			commandHandler.Commit().Should().BeTrue();
			churchDeletedEvent.Should().NotBeNull();
			churchDeletedEvent.Id.Should().NotBeEmpty();
			churchDeletedEvent.Id.Should().Be(argument.Id);

			//Verify that methods were invocation
			_mockChurchRepository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Never);
			_mockChurchRepository.Verify(x => x.Update(It.IsAny<Church>()), Times.Never);
			_mockChurchRepository.Verify(x => x.Remove(It.IsAny<Guid>()), Times.Once);
			_bus.Verify(x => x.RaiseEvent(It.IsAny<DomainNotification>()), Times.Never());
			_bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchDeletedEvent>()), Times.Once);
			_uow.Verify(x => x.Commit());
		}


	}
}