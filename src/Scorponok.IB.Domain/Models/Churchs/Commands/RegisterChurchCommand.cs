using System.Globalization;
using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public class RegisterChurchCommand : ChurchCommand
	{
	    public RegisterChurchCommand()
	    {
	        
	    }

		public RegisterChurchCommand(string name, string photo, string email, byte region, byte prefix, string number)
		{
			Name = name;
			Photo = photo;
			Email = email;
			Region = region;
			Prefix = prefix;
			Telephone = number;
		}

		public override bool IsValid()
		{
			var commandValidator = new RegisterChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}
	}
}