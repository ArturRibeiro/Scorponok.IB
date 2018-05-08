using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.ValueObjects;

namespace Scorponok.IB.Domain.Models.Organizacoes
{
	public class Organizacao : Entity
	{
		#region Propriedades
		public string Nome { get; private set; }
		public string Foto { get; private set; }
		public Email Email { get; private set; } = Email.Factory.Empty();
		public Telefone Telefone { get; private set; } = Telefone.Factory.Empty();
		public Endereco Endereco { get; private set; } = Endereco.Factory.Empty();
		#endregion

		public bool IsValid() => true;

		#region Factory
		public static class Factory
		{
			public static Organizacao CreateNew(string nome, string foto, Email email, Telefone telefone, Endereco endereco)
				=> new Organizacao()
				{
					Nome = nome,
					Foto = foto,
					Email = email,
					Telefone = telefone,
					Endereco = endereco
				};

			public static Organizacao CreateNew(string nome, string foto, Email email, Telefone telefone)
				=> new Organizacao()
				{
					Nome = nome,
					Foto = foto,
					Email = email,
					Telefone = telefone
				};

			public static Organizacao CreateNew(string nome, string foto, Email email)
				=> new Organizacao()
				{
					Nome = nome,
					Foto = foto,
					Email = email
				};

			public static Organizacao CreateNew(string nome, string foto)
				=> new Organizacao()
				{
					Nome = nome,
					Foto = foto
				};

			public static Organizacao CreateNew(string nome)
				=> new Organizacao()
				{
					Nome = nome
				};

		}
		#endregion


	}
}