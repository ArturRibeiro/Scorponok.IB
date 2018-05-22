using FluentValidation.Results;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Organizacoes.Commands
{
	public class RegisterChurchCommand : Command 
	{
		public ValidationResult ValidationResult
		{
			get;
			private set;
		}

		#region Propriedades
		public string Name { get; set; }
		public string Photo { get; }
		public string Email { get; }
		public string Telephone { get; }
		//public string Address { get; private set; }
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