namespace Scorponok.IB.Domain.Models.Churchs.Commands.Validators
{
	public class RegisterChurchCommandValidator : ChurchCommandValidator
	{
		public RegisterChurchCommandValidator()
		{
			this.ValidateName();
			this.ValidatePhoto();
			this.ValidateTelephone();
		}
	}
}