using FluentValidation;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Organizacoes.Commands
{
	public class RegisterChurchCommandValidator : CommandValidator<RegisterChurchCommand>
	{
		public RegisterChurchCommandValidator()
		{
			this.ValidateName();
			this.ValidatePhoto();
			this.ValidateTelephone();
		}

		private void ValidateName()
			=> RuleFor(c => c.Name)
				.NotEmpty()
					.WithMessage("Please, make sure you have entered the name correctly.")
				.Length(2, 150)
					.WithMessage("Name must be between 2 and 150 characters.");

		private void ValidatePhoto()
			=> RuleFor(c => c.Photo)
				.Length(1, 15)
					.WithMessage("Photo must be between 1 and 15 characters.");

		private void ValidateTelephone()
			=> RuleFor(c => c.Telephone)
				.Length(9)
					.WithMessage("Telephone must be between 8 and 9 characters.");
	}
}