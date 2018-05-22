using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Domain.Models.Organizacoes;

namespace Scorponok.IB.Unit.Tests.Domain.Models.Organizacoes
{
	[TestFixture, Category("Domain/Organizacoes/Church")]
	public class ChurchTests
	{
		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome()
		{
			//Arrange's
			var church = Church.Factory.CreateNew("nome");

			//Assert's
			church.Should().NotBeNull();
			church.Name.Should().Be("nome");
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto()
		{
			//Arrange's
			var church = Church.Factory.CreateNew("nome", "foto");

			//Assert's
			church.Should().NotBeNull();
			church.Name.Should().Be("nome");
			church.Photo.Should().Be("foto");
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email()
		{
			//Arrange's
			var church = Church.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"));

			//Assert's
			church.Should().NotBeNull();
			church.Name.Should().Be("nome");
			church.Photo.Should().Be("foto");
			church.Email.Should().NotBeNull();
			church.Email.Value.Should().Be("scorponok@scorponok.com");
			church.Email.Valido.Should().BeTrue();
			church.Email.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email_telefone()
		{
			//Arrange's
			var church = Church.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telephone.Factory.CreateNew(55, "21", "987413955"));

			//Assert's
			church.Should().NotBeNull();
			church.Name.Should().Be("nome");
			church.Photo.Should().Be("foto");

			church.Email.Should().NotBeNull();
			church.Email.Value.Should().Be("scorponok@scorponok.com");
			church.Email.Valido.Should().BeTrue();
			church.Email.Mensagem.Should().BeNullOrEmpty();

			church.Telephone.Numero.Should().Be("5521987413955");
			church.Telephone.Valido.Should().BeTrue();
			church.Telephone.Mensagem.Should().BeNullOrEmpty();
			church.Telephone.Mensagem.Should().BeNullOrEmpty();
		}

		[Test]
		public void Deve_cria_entidade_igreja_so_com_nome_foto_email_telefone_endereco()
		{
			//Arrange's
			var church = Church.Factory.CreateNew("nome", "foto"
				, Email.Factory.CreateNew("scorponok@scorponok.com")
				, Telephone.Factory.CreateNew(55, "21", "987413955")
				, Address.Factory.Empty());

			//Assert's
			church.Should().NotBeNull();
			church.Name.Should().Be("nome");
			church.Photo.Should().Be("foto");

			church.Email.Should().NotBeNull();
			church.Email.Value.Should().Be("scorponok@scorponok.com");
			church.Email.Valido.Should().BeTrue();
			church.Email.Mensagem.Should().BeNullOrEmpty();

			church.Telephone.Numero.Should().Be("5521987413955");
			church.Telephone.Valido.Should().BeTrue();
			church.Telephone.Mensagem.Should().BeNullOrEmpty();
			church.Telephone.Mensagem.Should().BeNullOrEmpty();
		}
	}
}