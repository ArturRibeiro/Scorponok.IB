using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Core.ValueObjects
{
	public class Endereco : ValueObject<Endereco>
	{
		internal Endereco()
		{
			
		}

		#region Factory

		public static class Factory
		{
			public static Endereco Empty()
				=> new Endereco();
		}

		#endregion
	}
}