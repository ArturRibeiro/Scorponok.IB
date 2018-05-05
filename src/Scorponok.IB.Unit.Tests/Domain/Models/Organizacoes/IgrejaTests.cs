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
			var igrega = Igreja.Factory.CreateNew("nome");

			//Assert's
			igrega.Should().NotBeNull();
			igrega.Nome.Should().Be("nome");
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto()
		{
			//Arrange's
			var igrega = Igreja.Factory.CreateNew("nome", "foto");

			//Assert's
			igrega.Should().NotBeNull();
			igrega.Nome.Should().Be("nome");
			igrega.Foto.Should().Be("foto");
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email()
		{
			//Arrange's
			var igrega = Igreja.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"));

			//Assert's
			igrega.Should().NotBeNull();
			igrega.Nome.Should().Be("nome");
			igrega.Foto.Should().Be("foto");
			igrega.Email.Should().NotBeNull();
			igrega.Email.Value.Should().Be("scorponok@scorponok.com");
			igrega.Email.Valido.Should().BeTrue();
			igrega.Email.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email_telefone()
		{
			//Arrange's
			var igrega = Igreja.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telefone.Factory.CreateNew(55, "21", "987413955"));

			//Assert's
			igrega.Should().NotBeNull();
			igrega.Nome.Should().Be("nome");
			igrega.Foto.Should().Be("foto");

			igrega.Email.Should().NotBeNull();
			igrega.Email.Value.Should().Be("scorponok@scorponok.com");
			igrega.Email.Valido.Should().BeTrue();
			igrega.Email.Mensagem.Should().BeNullOrEmpty();

			igrega.Telefone.Numero.Should().Be("5521987413955");
			igrega.Telefone.Valido.Should().BeTrue();
			igrega.Telefone.Mensagem.Should().BeNullOrEmpty();
			igrega.Telefone.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email_telefone_endereco()
		{
			//Arrange's
			var igrega = Igreja.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telefone.Factory.CreateNew(55, "21", "987413955"), Endereco.Factory.Empty());

			//Assert's
			igrega.Should().NotBeNull();
			igrega.Nome.Should().Be("nome");
			igrega.Foto.Should().Be("foto");

			igrega.Email.Should().NotBeNull();
			igrega.Email.Value.Should().Be("scorponok@scorponok.com");
			igrega.Email.Valido.Should().BeTrue();
			igrega.Email.Mensagem.Should().BeNullOrEmpty();

			igrega.Telefone.Numero.Should().Be("5521987413955");
			igrega.Telefone.Valido.Should().BeTrue();
			igrega.Telefone.Mensagem.Should().BeNullOrEmpty();
			igrega.Telefone.Mensagem.Should().BeNullOrEmpty();
		}
	}
}