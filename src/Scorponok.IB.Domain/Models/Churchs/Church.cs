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
		public Telephone CellPhone { get; private set; } = Telephone.Factory.Empty();
		public Telephone HomePhone { get; private set; } = Telephone.Factory.Empty();
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

		public Church UpdateTelephone(string cellPhone)
		{
			this.CellPhone.Update(cellPhone);
			return this;
		}

	    public Church UpdateHomePhone(string homePhone)
	    {
	        this.HomePhone.Update(homePhone);
	        return this;
	    }

        public Church UpdateAddress(string address)
		{
			return this;
		}

		#region Factory
		public static class Factory
		{
			public static Church CreateNew(string name, string photo, Email email, Telephone telephoneFixed, Telephone mobileTelephone, Address endereco)
				=> new Church()
				{
					Name = name,
					Photo = photo,
					Email = email,
				    CellPhone = mobileTelephone,
                    HomePhone = telephoneFixed,
                    Address = endereco
				};
		}
		#endregion
	}
}