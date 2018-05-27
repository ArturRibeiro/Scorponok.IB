using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Core.ValueObjects
{
	public class Address : ValueObject<Address>
	{
		internal Address()
		{
			
		}

		#region Factory

		public static class Factory
		{
			public static Address Empty()
				=> new Address();
		}

		#endregion
	}
}