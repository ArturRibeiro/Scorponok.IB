using Scorponok.IB.Core.Models;
using Scorponok.IB.Core.ValueObjects;

namespace Scorponok.IB.Domain.Models.Churchs
{
	public class Church : Entity
	{
		#region Propriedades
		public string Name { get; private set; }
		public string Photo { get; private set; }
		public Email Email { get; private set; } = Email.Factory.Empty();
		public Telephone MobileTelephone { get; private set; } = Telephone.Factory.Empty();
		public Telephone TelephoneFixed { get; private set; } = Telephone.Factory.Empty();
		public Address Address { get; private set; } = Address.Factory.Empty();
		#endregion

		public bool IsValid() => true;

		public Church UpdateName(string name)
		{
			this.Name = name;
			return this;
		}

		public Church UpdatePhoto(string photo)
		{
			this.Photo = photo;
			return this;
		}

		public Church UpdateEmail(string email)
		{
			this.Email.Update(email);
			return this;
		}

		public Church UpdateTelephone(string telephone)
		{
			this.MobileTelephone.Update(telephone);
			return this;
		}

		public Church UpdateAddress(string address)
		{
			return this;
		}

		#region Factory
		public static class Factory
		{
			public static Church CreateNew(string name, string photo, Email email, Telephone telephone, Address endereco)
				=> new Church()
				{
					Name = name,
					Photo = photo,
					Email = email,
					MobileTelephone = telephone,
					Address = endereco
				};

			public static Church CreateNew(string name, string photo, Email email, Telephone telephone)
				=> new Church()
				{
					Name = name,
					Photo = photo,
					Email = email,
					MobileTelephone = telephone
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