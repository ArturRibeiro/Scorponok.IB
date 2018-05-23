using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public class RegisterChurchCommand : ChurchCommand
	{
		public RegisterChurchCommand(string name, string photo, string email, string telephone)
		{
			Name = name;
			Photo = photo;
			Email = email;
			Telephone = telephone;
		}

		public override bool IsValid()
		{
			var commandValidator = new RegisterChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}
	}
}