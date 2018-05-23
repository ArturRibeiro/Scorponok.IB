using FluentValidation.Results;
using Scorponok.IB.Core.Commands;
using Scorponok.IB.Domain.Models.Organizacoes.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Organizacoes.Commands
{
	public class RegisterChurchCommand : Command 
	{
		#region Propriedades
		public string Name { get; }
		public string Photo { get; }
		public string Email { get; }
		public byte DDD { get; }
		public string Telephone { get; }
		#endregion

		public RegisterChurchCommand(string name, string photo, string email, string telephone)
		{
			Name = name;
			Photo = photo;
			Email = email;
			Telephone = telephone;
		}

		public override bool IsValid()
		{
			var commandValidator = new RegisterChurchCommandValidator();
			this.ValidationResult = commandValidator.Validate(this);

			return this.ValidationResult.IsValid;
		}
	}
}