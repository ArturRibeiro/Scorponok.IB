using System.Text.RegularExpressions;
using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Core.ValueObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Email : ValueObject<Email>
	{
		private const string EMAIL_PATTERN = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
		public const int EMAIL_MAX_LENGTH = 100;
		public const int EMAIL_MIN_LENGTH = 5;

		#region Properties
		public string Value { get; private set; }

		public bool Valido { get; private set; }

		public string Mensagem { get; private set; }
		#endregion

		protected Email()
		{
			Valido = false;
			Value = null;
			Mensagem = null;
		}

		public Email(string email) : this()
		{
			this.Value = email;
			Validar();
		}

		private void Validar()
		{
			if (this.Value.Length > EMAIL_MAX_LENGTH)
				this.Mensagem = $"E-mail: {this.Value} informado ultrapassou a quantidade permitida de {EMAIL_MAX_LENGTH}";
			else if (this.Value.Length < EMAIL_MIN_LENGTH)
				this.Mensagem = $"E-mail: {this.Value} informado não possui a quantidade mínima permitida de {EMAIL_MIN_LENGTH}";
			else
			{
				var result = Regex.IsMatch(this.Value, EMAIL_PATTERN);

				if (!result) this.Mensagem = $"E-mail: {this.Value} inváido";
				else
					this.Valido = true;
			}
		}

		public class Factory
		{
			public static Email CreateNew(string email)
				=> new Email(email);

			public static Email Empty()
				=> new Email();
		}

		public void Update(string email)
			=> this.Value = email;
	}
}