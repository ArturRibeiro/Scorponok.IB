using System;
using System.Runtime.InteropServices.ComTypes;
using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Core.ValueObjects
{
	public class Telephone : ValueObject<Telephone>
	{
		#region Properties

		public byte Pais { get; private set; } = 55;

		public byte DDD { get; private set; }

		public string Numero { get; private set; }

		public bool Valido { get; private set; }

		public string Mensagem { get; private set; }
		#endregion

		public Telephone()
		{

		}

		private Telephone(byte codigoPais, byte ddd, string numero)
		{
			this.Pais = codigoPais;
			this.DDD = ddd;
			this.Numero = numero;
			Valido = Validar();
		}

		private bool Validar()
		{
			if (this.Pais != 55)
			{
				this.Mensagem = "Código do país incorreto.";
				return false;
			}
			
			if (this.DDD < 1 || this.DDD > 99)
			{
				this.Mensagem = "DDD incorreto";
				return false;
			}

			if (string.IsNullOrEmpty(this.Numero))
			{
				this.Mensagem = "Número inválido.";
				return false;
			}
			
			this.Numero = $"{this.Pais}{this.DDD}{this.Numero}";

			return true;
		}

		public void Update(string number) 
			=> this.Numero = number;

		#region Factory

		public static class Factory
		{
			public static Telephone CreateNew(byte codigoPais, byte ddd, string numero)
				=> new Telephone(codigoPais, ddd, numero);

			public static Telephone Empty()
				=> new Telephone();

			public static Telephone CreateNew(byte ddd, string numero)
				=> new Telephone()
				{
					DDD = ddd,
					Numero = numero
				};
		}

		#endregion
	}
}