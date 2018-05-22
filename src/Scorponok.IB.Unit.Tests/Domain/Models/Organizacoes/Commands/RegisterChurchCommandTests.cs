using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Domain.Models.Organizacoes.Commands;

namespace Scorponok.IB.Unit.Tests.Domain.Models.Organizacoes.Commands
{
	[TestFixture, Category("Domain/Church/Commands/Arguments")]
	public class RegisterChurchCommandTests
	{
		[Test]
		public void Registering_church_with_the_150_largest_name_should_fail()
		{
			//Arrange's
			var commandArg = new RegisterChurchCommand(@"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
														 aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
														 ssssssssssssssssssssssssssssssssssssssssssssss
														 aaaaaaaaaaaaaaaaaaaaaaaaasssssssssssssssssssss
														 ssssssssssssssssssssssssssssssssssssssssssssss", email: "Scorponok@scorponok.com", photo: "...", telephone: "219874133");

			//Assert's
			commandArg.IsValid().Should().BeFalse();
			commandArg.ValidationResult.Errors.Should().HaveCount(1);
			commandArg.ValidationResult.Errors.Should()
				.Contain(x => x.ErrorMessage == "Name must be between 2 and 150 characters.");
		}

		[Test]
		public void Registering_church_with_photo_large_than_15_should_fail()
		{
			//Arrange's
			var commandArg = new RegisterChurchCommand("Richmond’s First Baptist Church", email: "Scorponok@scorponok.com", photo: "", telephone: "219874133");


			//Assert's
			commandArg.IsValid().Should().BeFalse();
			commandArg.ValidationResult.Errors.Should().HaveCount(1);
			commandArg.ValidationResult.Errors.Should()
				.Contain(x => x.ErrorMessage == "Photo must be between 1 and 15 characters.");
		}

		[Test]
		public void Registering_church_with_telephone_larger_than_9_should_fail()
		{
			//Arrange's
			var commandArg = new RegisterChurchCommand("Richmond’s First Baptist Church", email: "Scorponok@scorponok.com", photo: "test.jpg", telephone: "98741397855");


			//Assert's
			commandArg.IsValid().Should().BeFalse();
			commandArg.ValidationResult.Errors.Should().HaveCount(1);
			commandArg.ValidationResult.Errors.Should()
				.Contain(x => x.ErrorMessage == "Telephone must be between 8 and 9 characters.");
		}

		[Test]
		public void Registering_church_with_telephone_less_than_8_should_fail()
		{
			//Arrange's
			var commandArg = new RegisterChurchCommand("Richmond’s First Baptist Church", email: "Scorponok@scorponok.com", photo: "test.jpg", telephone: "0123456");


			//Assert's
			commandArg.IsValid().Should().BeFalse();
			commandArg.ValidationResult.Errors.Should().HaveCount(1);
			commandArg.ValidationResult.Errors.Should()
				.Contain(x => x.ErrorMessage == "Telephone must be between 8 and 9 characters.");
		}
	}
}