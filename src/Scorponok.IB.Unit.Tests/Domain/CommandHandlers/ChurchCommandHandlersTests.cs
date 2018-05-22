//using FluentAssertions;

using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;

namespace Scorponok.IB.Unit.Tests.Domain.CommandHandlers
{
	[TestFixture, Category("Domain/CommandHandlers/Church")]
	public class ChurchCommandHandlersTests
	{
		[Test]
		public void Must_register_a_church_successfully()
		{
			var commandHandler = new ChurchCommandHandlers();

			var commandArg = new RegisterChurchCommand("1", email: "Scorponok@scorponok.com", photo: "..", telephone: "2198741333");

			commandArg.IsValid();

			commandHandler.Handle(commandArg);
		}


	}
}