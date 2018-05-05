using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Core.ValueObjects;

namespace Scorponok.IB.Unit.Tests.Domain.Models.ValueObjects
{
	[TestFixture, Category("Domain/Organizacoes/Telefone/ValueObjects")]
	public class TelefoneMovelTests
	{
		[TestCase(55, "21", "987413977")]
		[TestCase(55, "21", "27620537")]
		public void Deve_validar_telefone_com_sucesso(byte codigoPais, string ddd, string numero)
		{
			var telefone = Telefone.Factory.CreateNew(codigoPais, ddd, numero);

			telefone.Should().NotBeNull();
			telefone.Valido.Should().BeTrue();
		}

		[Test]
		public void Deve_validar_codigo_pais_incorreto_vazios_com_sucesso()
		{
			var telefone = Telefone.Factory.CreateNew(0, "0", null);

			telefone.Should().NotBeNull();
			telefone.Valido.Should().BeFalse();
			telefone.Mensagem.Should().Be("Código do país incorreto.");
		}

		[TestCase("0")]
		[TestCase("100")]
		[TestCase("9")]
		public void Deve_validar_ddd_incorreto_com_sucesso(string dddd)
		{
			var telefone = Telefone.Factory.CreateNew(55, dddd, "999999999");

			telefone.Should().NotBeNull();
			telefone.Valido.Should().BeFalse();
			telefone.Mensagem.Should().Be("DDD incorreto");
		}

		[TestCase(55, "21", "987413977")]
		public void Deve_entender_as_duas_instancias_de_telefone_com_sucesso(byte codigoPais, string ddd, string numero)
		{
			var telefone1 = Telefone.Factory.CreateNew(codigoPais, ddd, numero);
			var telefone2 = Telefone.Factory.CreateNew(codigoPais, ddd, numero);

			telefone1.Should().NotBeNull();
			telefone2.Valido.Should().BeTrue();

			telefone1.Equals(telefone2).Should().BeTrue();

		}
	}
}