using FluentValidation;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Churchs.Commands.Validators
{
	public class ChurchCommandValidator : CommandValidator<ChurchCommand>
	{
		protected void ValidateName()
			=> RuleFor(c => c.Name)
				.NotEmpty()
					.WithMessage("Please, make sure you have entered the name correctly.")
				.Length(2, 150)
					.WithMessage("Name must be between 2 and 150 characters.");

        protected void ValidatePhoto()
            => RuleFor(c => c.Photo)
                .Length(1, 15)
                    .WithMessage("Photo must be between 1 and 15 characters.");

        protected void ValidateMobileTelephone()
			=> RuleFor(c => c.PhoneMobile)
				.Length(9)
					.WithMessage("Telephone must be between 8 and 9 characters.");

	    protected void ValidatePhoneFixed()
	        => RuleFor(c => c.PhoneFixed)
	            .Length(8)
	            .WithMessage("The phone must be a maximum of 8 characters.");

        protected void ValidateId()
			=> RuleFor(c => c.Id)
				.NotEmpty()
				.WithMessage("Please make sure you entered the id correctly.");
	}
}