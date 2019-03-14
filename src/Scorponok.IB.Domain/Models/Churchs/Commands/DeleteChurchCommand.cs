using System;
using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public class DeleteChurchCommand : ChurchCommand
	{
		public override bool IsValid()
		{
			var commandValidator = new DeleteChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}

	    #region Factory

	    public static class Factory
	    {
	        public static DeleteChurchCommand Create(Guid id)
	        {
	            return new DeleteChurchCommand()
	            {
	                Id = id
                };
	        }
	    }

	    #endregion
    }
}