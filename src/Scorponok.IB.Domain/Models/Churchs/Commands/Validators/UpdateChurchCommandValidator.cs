namespace Scorponok.IB.Domain.Models.Churchs.Commands.Validators
{
	public class UpdateChurchCommandValidator : ChurchCommandValidator
	{
		public UpdateChurchCommandValidator()
		{
			this.ValidateId();
			this.ValidateName();
			this.ValidateMobileTelephone();
		}
	}
}