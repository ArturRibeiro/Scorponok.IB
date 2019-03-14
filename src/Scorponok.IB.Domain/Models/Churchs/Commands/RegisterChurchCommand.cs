using System.Globalization;
using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
	public class RegisterChurchCommand : ChurchCommand
	{
		public override bool IsValid()
		{
			var commandValidator = new RegisterChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}

	    #region Factory

	    public static class Factory
	    {
            public static RegisterChurchCommand Create(string name, string photo, string email, byte region, byte prefix, string cellPhone, string homePhone)
            {
                return new RegisterChurchCommand()
                {
                    Name = name,
                    Photo = photo,
                    Email = email,
                    Region = region,
                    Prefix = prefix,
                    CellPhone = cellPhone,
                    HomePhone = homePhone
                };
            }
        }

        #endregion
    }
}