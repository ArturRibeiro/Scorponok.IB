using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Organizacoes.CommandHandlers;
using Scorponok.IB.Domain.Models.Organizacoes.EventHandlers.Events;
using Scorponok.IB.Domain.Models.Organizacoes.IRespository;

namespace Scorponok.IB.Unit.Tests.Domain.Models.Organizacoes.CommandHandlers
{
	[TestFixture, Category("Domain/Models/Organizacoes/CommandHandlers")]
	public class OrganicaoCommandHandlerTests
	{
		private readonly Mock<IUnitOfWork> _uow;
		private readonly Mock<IBus> _bus;
		private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notification;
		private readonly Mock<IChurchRepository> _mockOrganizacaoRepository;

		public OrganicaoCommandHandlerTests()
		{
			_uow = new Mock<IUnitOfWork>();
			_bus = new Mock<IBus>();
			_notification = new Mock<IDomainNotificationHandler<DomainNotification>>();
			_mockOrganizacaoRepository = new Mock<IChurchRepository>();
		}

		[Test]
		public void Deve_criar_uma_nova_organizacao_com_sucesso()
		{
			//Arrange's
			var novaOrganizacaoEventCommand = new NovaOrganizacaoEventCommand(nome: "Scorponok 3d", foto: "teste", email: "scorponok3d@gmail.com", ddd: "21", telefone: "99999999");

			var command = new OrganicaoCommandHandler(
				  _uow.Object
				, _bus.Object
				, _notification.Object
				, _mockOrganizacaoRepository.Object);

			//Stub's
			_uow.Setup(x => x.Commit()).Returns(CommandResult.Ok);

			//Act's
			command.Handle(novaOrganizacaoEventCommand);

			//Assert's
			command.Commit().Should().BeTrue();
		}

		[Test]
		public void Deve_criar_uma_nova_organizacao_validando_argumento_null_com_sucesso()
		{
			//Arrange's

			var command = new OrganicaoCommandHandler(_uow.Object
				, _bus.Object
				, _notification.Object
				, _mockOrganizacaoRepository.Object);

			//Act's
			Action action = () => { command.Handle(null); };

			//Assert's
			action.Should()
				.Throw<ArgumentNullException>();
		}
	}
}