namespace Scorponok.IB.Domain.Models.Churchs.Commands.Validators
{
	public class DeleteChurchCommandValidator : ChurchCommandValidator
	{
		public DeleteChurchCommandValidator()
			=>	ValidateId();
	}
}