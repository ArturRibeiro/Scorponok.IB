using System;
using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public class DeleteChurchCommand : ChurchCommand
	{
		public DeleteChurchCommand(Guid id)
			=> Id = id;
		

		public override bool IsValid()
		{
			var commandValidator = new DeleteChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}
	}
}