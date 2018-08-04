namespace Scorponok.IB.Domain.Models.Churchs.Commands.Validators
{
	public class RegisterChurchCommandValidator : ChurchCommandValidator
	{
		public RegisterChurchCommandValidator()
		{
			this.ValidateName();
			this.ValidatePhoneFixed();
            this.ValidatePhoto();
            this.ValidateMobileTelephone();
            this.ValidatePhoneFixed();
		}
	}
}