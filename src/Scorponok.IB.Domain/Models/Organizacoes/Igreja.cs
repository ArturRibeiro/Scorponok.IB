using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.ValueObjects;

namespace Scorponok.IB.Domain.Models.Organizacoes
{
	public class Igreja : Entity
	{
		#region Propriedades
		public string Nome { get; private set; }
		public string Foto { get; private set; }
		public Email Email { get; private set; } = Email.Factory.Empty();
		public Telefone Telefone { get; private set; } = Telefone.Factory.Empty();
		public Endereco Endereco { get; private set; } = Endereco.Factory.Empty();
		#endregion

		#region Factory
		public static class Factory
		{
			public static Igreja CreateNew(string nome, string foto, Email email, Telefone telefone, Endereco endereco)
				=> new Igreja()
				{
					Nome = nome,
					Foto = foto,
					Email = email,
					Telefone = telefone,
					Endereco = endereco
				};

			public static Igreja CreateNew(string nome, string foto, Email email, Telefone telefone)
				=> new Igreja()
				{
					Nome = nome,
					Foto = foto,
					Email = email,
					Telefone = telefone
				};

			public static Igreja CreateNew(string nome, string foto, Email email)
				=> new Igreja()
				{
					Nome = nome,
					Foto = foto,
					Email = email
				};

			public static Igreja CreateNew(string nome, string foto)
				=> new Igreja()
				{
					Nome = nome,
					Foto = foto
				};

			public static Igreja CreateNew(string nome)
				=> new Igreja()
				{
					Nome = nome
				};

		}
		#endregion
	}
}