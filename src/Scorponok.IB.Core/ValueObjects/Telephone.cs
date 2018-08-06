using System;
using System.Runtime.InteropServices.ComTypes;
using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Core.ValueObjects
{
	public class Telephone : ValueObject<Telephone>
	{
		#region Properties

		public byte Region { get; private set; } = 55;

		public byte Prefix { get; private set; }

		public string Number { get; private set; }

		public bool Valido { get; private set; }

		public string Mensagem { get; private set; }
		#endregion

		public Telephone()
		{

		}

		private Telephone(byte codigoPais, byte ddd, string numero)
		{
			this.Region = codigoPais;
			this.Prefix = ddd;
			this.Number = numero;
			Valido = Validar();
		}
        
        private bool Validar()
		{
			if (this.Region != 55)
			{
				this.Mensagem = "Código do país incorreto.";
				return false;
			}
			
			if (this.Prefix < 1 || this.Prefix > 99)
			{
				this.Mensagem = "DDD incorreto";
				return false;
			}

			if (string.IsNullOrEmpty(this.Number))
			{
				this.Mensagem = "Número inválido.";
				return false;
			}
			
			this.Number = $"{this.Region}{this.Prefix}{this.Number}";

			return true;
		}

		public void Update(string number) 
			=> this.Number = number;

		#region Factory

		public static class Factory
		{
            public static Telephone CreateNew(byte region, byte ddd, string number)
				=> new Telephone(region, ddd, number);

			public static Telephone Empty()
				=> new Telephone();

			public static Telephone CreateNew(byte ddd, string numero)
				=> new Telephone()
				{
					Prefix = ddd,
					Number = numero
				};

		    public static Telephone CreateNew(string numero)
		        => new Telephone()
		        {
		            Number = numero
		        };
        }

		#endregion
	}
}