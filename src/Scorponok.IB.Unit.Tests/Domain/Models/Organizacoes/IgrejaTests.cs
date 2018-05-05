using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Domain.Models.Organizacoes;

namespace Scorponok.IB.Unit.Tests.Domain.Models.Organizacoes
{
	[TestFixture, Category("Domain/Organizacoes/Igreja")]
	public class IgrejaTests
	{
		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome()
		{
			//Arrange's
			var igreja = Igreja.Factory.CreateNew("nome");

			//Assert's
			igreja.Should().NotBeNull();
			igreja.Nome.Should().Be("nome");
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto()
		{
			//Arrange's
			var igreja = Igreja.Factory.CreateNew("nome", "foto");

			//Assert's
			igreja.Should().NotBeNull();
			igreja.Nome.Should().Be("nome");
			igreja.Foto.Should().Be("foto");
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email()
		{
			//Arrange's
			var igreja = Igreja.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"));

			//Assert's
			igreja.Should().NotBeNull();
			igreja.Nome.Should().Be("nome");
			igreja.Foto.Should().Be("foto");
			igreja.Email.Should().NotBeNull();
			igreja.Email.Value.Should().Be("scorponok@scorponok.com");
			igreja.Email.Valido.Should().BeTrue();
			igreja.Email.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email_telefone()
		{
			//Arrange's
			var igreja = Igreja.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telefone.Factory.CreateNew(55, "21", "987413955"));

			//Assert's
			igreja.Should().NotBeNull();
			igreja.Nome.Should().Be("nome");
			igreja.Foto.Should().Be("foto");

			igreja.Email.Should().NotBeNull();
			igreja.Email.Value.Should().Be("scorponok@scorponok.com");
			igreja.Email.Valido.Should().BeTrue();
			igreja.Email.Mensagem.Should().BeNullOrEmpty();

			igreja.Telefone.Numero.Should().Be("5521987413955");
			igreja.Telefone.Valido.Should().BeTrue();
			igreja.Telefone.Mensagem.Should().BeNullOrEmpty();
			igreja.Telefone.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email_telefone_endereco()
		{
			//Arrange's
			var igreja = Igreja.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telefone.Factory.CreateNew(55, "21", "987413955"), Endereco.Factory.Empty());

			//Assert's
			igreja.Should().NotBeNull();
			igreja.Nome.Should().Be("nome");
			igreja.Foto.Should().Be("foto");

			igreja.Email.Should().NotBeNull();
			igreja.Email.Value.Should().Be("scorponok@scorponok.com");
			igreja.Email.Valido.Should().BeTrue();
			igreja.Email.Mensagem.Should().BeNullOrEmpty();

			igreja.Telefone.Numero.Should().Be("5521987413955");
			igreja.Telefone.Valido.Should().BeTrue();
			igreja.Telefone.Mensagem.Should().BeNullOrEmpty();
			igreja.Telefone.Mensagem.Should().BeNullOrEmpty();
		}
	}
}