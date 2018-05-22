using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.ValueObjects;

namespace Scorponok.IB.Domain.Models.Organizacoes
{
	public class Church : Entity
	{
		#region Propriedades
		public string Name { get; private set; }
		public string Photo { get; private set; }
		public Email Email { get; private set; } = Email.Factory.Empty();
		public Telephone Telephone { get; private set; } = Telephone.Factory.Empty();
		public Address Address { get; private set; } = Address.Factory.Empty();
		#endregion

		#region Factory
		public static class Factory
		{
			public static Church CreateNew(string name, string photo, Email email, Telephone telephone, Address endereco)
				=> new Church()
				{
					Name = name,
					Photo = photo,
					Email = email,
					Telephone = telephone,
					Address = endereco
				};

			public static Church CreateNew(string name, string photo, Email email, Telephone telephone)
				=> new Church()
				{
					Name = name,
					Photo = photo,
					Email = email,
					Telephone = telephone
				};

			public static Church CreateNew(string name, string photo, Email email)
				=> new Church()
				{
					Name = name,
					Photo = photo,
					Email = email
				};

			public static Church CreateNew(string name, string photo)
				=> new Church()
				{
					Name = name,
					Photo = photo
				};

			public static Church CreateNew(string name)
				=> new Church()
				{
					Name = name
				};

		}
		#endregion
	}
}