using System;
using System.Threading;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Interfaces;
using Scorponok.IB.Domain.Models.Churchs;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Domain.Models.Churchs.Events;
using Scorponok.IB.Domain.Models.Churchs.IRepository;

namespace Scorponok.IB.Unit.Tests.Domain.CommandHandlers
{
    [TestFixture, Category("Domain/CommandHandlers/Church")]
    public class ChurchCommandHandlersTests
    {
        [Test]
        public async Task Registering_church_successfully()
        {
            //Arrange's
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IBus>();
            var notification = new Mock<DomainNotificationHandler>();
            var mockChurchRepository = new Mock<IChurchRepository>();

            var argument = new RegisterChurchCommand("Richmond’s First Baptist Church",
                email: "Scorponok@scorponok.com",
                photo: "1.jpg",
                region: 55,
                prefix: 21,
                number: "123456789");

            //Setup
            uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));

            //Act's
            var commandHandler = new ChurchCommandHandler(uow.Object, bus.Object, notification.Object, mockChurchRepository.Object);
            await commandHandler.Handle(argument, CancellationToken.None);

            //Assert's
            commandHandler.Commit().Should().BeTrue();

            //Verify that methods were invocation
            mockChurchRepository.Verify(x => x.Add(It.IsAny<Church>()), Times.Once);
            bus.Verify(x => x.RaiseEvent(It.IsAny<DomainNotification>()), Times.Never());
            uow.Verify(x => x.Commit());
            bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchRegisteredEvent>()), Times.Once);
        }

        [Test]
        public async Task Registering_church_with_argument_invalid()
        {
            //Arrange's
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IBus>();
            var domainNotification = new Mock<DomainNotificationHandler>();
            var mockChurchRepository = new Mock<IChurchRepository>();

            var arguments = new RegisterChurchCommand(
                name: @"Richmond’s First Baptist ChurchRichmond’s First Baptist ChurchRichmond’s 
						First Baptist ChurchRichmond’s First Baptist ChurchRichmond’s First Baptist Church
						Richmond’s First Baptist Church"
                , email: "Scorponok@scorponok.com"
                , photo: "1.jpg"
                , region: 55
                , prefix: 21
                , number: "123456789");

            DomainNotification domainNotificationResult = null;

            bus.Setup(x => x.RaiseEvent(It.IsAny<DomainNotification>()))
                .Callback<DomainNotification>(notification => domainNotificationResult = notification);

            //Act's
            var commandHandler = new ChurchCommandHandler(
                uow.Object, bus.Object
                , domainNotification.Object, mockChurchRepository.Object);
            await commandHandler.Handle(arguments, CancellationToken.None);

            //Assert's
            domainNotification.Should().NotBeNull();
            domainNotificationResult.AggregateId.Should().Be(Guid.Empty);
            domainNotificationResult.Key.Should().Be("Name");
            domainNotificationResult.MessageType.Should().Be("DomainNotification");
            domainNotificationResult.Value.Should().Be("Name must be between 2 and 150 characters.");
        }

        [Test]
        public async Task Updating_church_successfully()
        {
            //Arrange's
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IBus>();
            var notification = new Mock<DomainNotificationHandler>();
            var mockChurchRepository = new Mock<IChurchRepository>();

            var argument = new UpdateChurchCommand(id: Guid.NewGuid()
                    , name: "Richmond’s First Baptist Church"
                    , email: "Scorponok@scorponok.com"
                    , photo: "1.jpg"
                    , telephone: "123456789");

            //Setup
            uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));
            mockChurchRepository.Setup(x => x.GetById(argument.Id))
                .Returns(Builder<Church>
                    .CreateNew()
                .Build);

            //Act's
            var commandHandler = new ChurchCommandHandler(uow.Object, bus.Object, notification.Object, mockChurchRepository.Object);
            await commandHandler.Handle(argument, CancellationToken.None);

            //Assent's
            commandHandler.Commit().Should().BeTrue();

            //Verify that methods were invocation
            mockChurchRepository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            mockChurchRepository.Verify(x => x.Update(It.IsAny<Church>()), Times.Once);
            bus.Verify(x => x.RaiseEvent(It.IsAny<DomainNotification>()), Times.Never());
            uow.Verify(x => x.Commit());
            bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchUpdatedEvent>()), Times.Once);
        }

        [Test]
        public async Task Updating_church_with_argument_invalid()
        {
            //Arrange's
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IBus>();
            var domainNotification = new Mock<DomainNotificationHandler>();
            var mockChurchRepository = new Mock<IChurchRepository>();

            var arguments = new UpdateChurchCommand(
                id: Guid.NewGuid(),
                name: @"Richmond’s First Baptist ChurchRichmond’s First Baptist ChurchRichmond’s 
						First Baptist ChurchRichmond’s First Baptist ChurchRichmond’s First Baptist Church
						Richmond’s First Baptist Church"
                , email: "Scorponok@scorponok.com"
                , photo: "1.jpg"
                , telephone: "123456789");

            DomainNotification domainNotificationResult = null;

            bus.Setup(x => x.RaiseEvent(It.IsAny<DomainNotification>()))
                .Callback<DomainNotification>(notification => domainNotificationResult = notification);

            //Act's
            var commandHandler = new ChurchCommandHandler(
                uow.Object, bus.Object
                , domainNotification.Object, mockChurchRepository.Object);
            await commandHandler.Handle(arguments, CancellationToken.None);

            //Assert's
            domainNotification.Should().NotBeNull();
            domainNotificationResult.AggregateId.Should().Be(Guid.Empty);
            domainNotificationResult.Key.Should().Be("Name");
            domainNotificationResult.MessageType.Should().Be("DomainNotification");
            domainNotificationResult.Value.Should().Be("Name must be between 2 and 150 characters.");
        }

        [Test]
        public async Task Deleting_church_successfully()
        {
            //Arrange's
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IBus>();
            var domainNotification = new Mock<DomainNotificationHandler>();
            var mockChurchRepository = new Mock<IChurchRepository>();

            var argument = new DeleteChurchCommand(id: Guid.NewGuid());

            //Setup
            uow.Setup(x => x.Commit()).Returns(new CommandResult(success: true));

            //Act's
            var commandHandler = new ChurchCommandHandler(uow.Object, bus.Object
                , domainNotification.Object, mockChurchRepository.Object);
            await commandHandler.Handle(argument, CancellationToken.None);

            //Assent's
            commandHandler.Commit().Should().BeTrue();

            //Verify that methods were invocation
            mockChurchRepository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Never);
            mockChurchRepository.Verify(x => x.Update(It.IsAny<Church>()), Times.Never);
            mockChurchRepository.Verify(x => x.Remove(It.IsAny<Guid>()), Times.Once);
            bus.Verify(x => x.RaiseEvent(It.IsAny<DomainNotification>()), Times.Never());
            bus.Verify(x => x.RaiseEvent(It.IsAny<ChurchDeletedEvent>()), Times.Once);
            uow.Verify(x => x.Commit());
        }

        [Test]
        public async Task Deleting_church_with_id_incorrect()
        {
            //Arrange's
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IBus>();
            var domainNotification = new Mock<DomainNotificationHandler>();
            var mockChurchRepository = new Mock<IChurchRepository>();

            var arguments = new DeleteChurchCommand(
                id: Guid.Empty);

            DomainNotification domainNotificationResult = null;

            bus.Setup(x => x.RaiseEvent(It.IsAny<DomainNotification>()))
                .Callback<DomainNotification>(notification => domainNotificationResult = notification);

            //Act's
            var commandHandler = new ChurchCommandHandler(
                uow.Object, bus.Object
                , domainNotification.Object, mockChurchRepository.Object);
            await commandHandler.Handle(arguments, CancellationToken.None);

            //Assert's
            domainNotification.Should().NotBeNull();
            domainNotificationResult.AggregateId.Should().Be(Guid.Empty);
            domainNotificationResult.Key.Should().Be("Id");
            domainNotificationResult.MessageType.Should().Be("DomainNotification");
            domainNotificationResult.Value.Should().Be("Please make sure you entered the id correctly.");
        }


    }
}