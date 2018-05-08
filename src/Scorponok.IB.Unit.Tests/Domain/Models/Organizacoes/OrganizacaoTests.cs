using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Domain.Models.Organizacoes;

namespace Scorponok.IB.Unit.Tests.Domain.Models.Organizacoes
{
	[TestFixture, Category("Domain/Organizacoes/Igreja")]
	public class OrganizacaoTests
	{
		[Test]
		public void Deve_cria_entidade_organizacao_so_com_nome()
		{
			//Arrange's
			var organizacao = Organizacao.Factory.CreateNew("nome");

			//Assert's
			organizacao.Should().NotBeNull();
			organizacao.Nome.Should().Be("nome");
		}

		[Test]
		public void Deve_cria_entidade_organizacao_so_com_nome_foto()
		{
			//Arrange's
			var organizacao = Organizacao.Factory.CreateNew("nome", "foto");

			//Assert's
			organizacao.Should().NotBeNull();
			organizacao.Nome.Should().Be("nome");
			organizacao.Foto.Should().Be("foto");
		}

		[Test]
		public void Deve_cria_entidade_organizacao_so_com_nome_foto_email()
		{
			//Arrange's
			var organizacao = Organizacao.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"));

			//Assert's
			organizacao.Should().NotBeNull();
			organizacao.Nome.Should().Be("nome");
			organizacao.Foto.Should().Be("foto");
			organizacao.Email.Should().NotBeNull();
			organizacao.Email.Value.Should().Be("scorponok@scorponok.com");
			organizacao.Email.Valido.Should().BeTrue();
			organizacao.Email.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_organizacao_so_com_nome_foto_email_telefone()
		{
			//Arrange's
			var organizacao = Organizacao.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telefone.Factory.CreateNew(55, "21", "987413955"));

			//Assert's
			organizacao.Should().NotBeNull();
			organizacao.Nome.Should().Be("nome");
			organizacao.Foto.Should().Be("foto");

			organizacao.Email.Should().NotBeNull();
			organizacao.Email.Value.Should().Be("scorponok@scorponok.com");
			organizacao.Email.Valido.Should().BeTrue();
			organizacao.Email.Mensagem.Should().BeNullOrEmpty();

			organizacao.Telefone.Numero.Should().Be("5521987413955");
			organizacao.Telefone.Valido.Should().BeTrue();
			organizacao.Telefone.Mensagem.Should().BeNullOrEmpty();
			organizacao.Telefone.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_organizacao_so_com_nome_foto_email_telefone_endereco()
		{
			//Arrange's
			var email = Email.Factory.CreateNew("scorponok@scorponok.com");
			var telefone = Telefone.Factory.CreateNew(55, "21", "987413955");
			var endereco = Endereco.Factory.Empty();

			var organizacao = Organizacao.Factory.CreateNew("nome", "foto", email, telefone, endereco);

			//Assert's
			organizacao.Should().NotBeNull();
			organizacao.Nome.Should().Be("nome");
			organizacao.Foto.Should().Be("foto");

			organizacao.Email.Should().NotBeNull();
			organizacao.Email.Value.Should().Be("scorponok@scorponok.com");
			organizacao.Email.Valido.Should().BeTrue();
			organizacao.Email.Mensagem.Should().BeNullOrEmpty();

			organizacao.Telefone.Numero.Should().Be("5521987413955");
			organizacao.Telefone.Valido.Should().BeTrue();
			organizacao.Telefone.Mensagem.Should().BeNullOrEmpty();
			organizacao.Telefone.Mensagem.Should().BeNullOrEmpty();
		}
	}
}