using System;
using System.Runtime.InteropServices.ComTypes;

namespace Scorponok.IB.Core.ValueObjects
{
	public class Telefone : ValueObject<Telefone>
	{
		#region Properties

		public byte Pais { get; private set; } = 55;

		public byte DDD { get; private set; }

		public string Numero { get; private set; }

		public bool Valido { get; private set; }
		#endregion


		private Telefone(byte codigoPais, byte ddd, string numero)
		{
			this.Pais = codigoPais;
			this.DDD = ddd;
			this.Numero = numero;
			Valido = Validar();
		}

		private bool Validar()
		{
			var numeroValido =  (this.Pais == 55)
			       && this.DDD <= 99
			       && !string.IsNullOrEmpty(this.Numero);

			if (!numeroValido) return false;

			this.Numero = $"{this.Pais}{this.DDD}{this.Numero}";

			return true;
		}

		#region Factory

		public static class Factory
		{
			public static Telefone CreateNew(byte codigoPais, byte ddd, string numero)
				=> new Telefone(codigoPais, ddd, numero);
		}

		#endregion
	}
}