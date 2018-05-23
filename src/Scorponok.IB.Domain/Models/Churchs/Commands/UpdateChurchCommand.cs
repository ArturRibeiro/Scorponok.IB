using System;
using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public class UpdateChurchCommand : ChurchCommand
	{
		public UpdateChurchCommand(Guid id, string name, string photo, string email, string telephone)
		{
			Id = id;
			Name = name;
			Photo = photo;
			Email = email;
			Telephone = telephone;
		}

		public override bool IsValid()
		{
			var commandValidator = new UpdateChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}

	}
}