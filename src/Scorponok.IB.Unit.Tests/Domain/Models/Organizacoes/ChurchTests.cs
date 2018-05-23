﻿using FluentAssertions;
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
			var church = Church.Factory.CreateNew("nome", "foto", Email.Factory.CreateNew("scorponok@scorponok.com"), Telephone.Factory.CreateNew(55, 21, "987413955"));

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
				, Telephone.Factory.CreateNew(55, 21, "987413955")
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

		[Test]
		public void Update_name()
		=> Church.Factory.CreateNew("nome", "foto"
				, Email.Factory.CreateNew("scorponok@scorponok.com")
				, Telephone.Factory.CreateNew(55, 21, "987413955")
				, Address.Factory.Empty())
				.UpdateName("test")
			.Name
			.Should()
			.Be("test");
		
		[Test]
		public void Update_email()
			=> Church.Factory.CreateNew("nome", "foto"
				, Email.Factory.CreateNew("scorponok@scorponok.com")
				, Telephone.Factory.CreateNew(55, 21, "987413955")
				, Address.Factory.Empty())
				.UpdateEmail("test@test.com")
			.Email
			.Value
			.Should()
			.Be("test@test.com");
		
		[Test]
		public void Update_photo()
			=> Church.Factory.CreateNew("nome", "foto"
				, Email.Factory.CreateNew("scorponok@scorponok.com")
				, Telephone.Factory.CreateNew(55, 21, "987413955")
				, Address.Factory.Empty())
				.UpdatePhoto("33.jpg")
			.Photo.Should()
			.Be("33.jpg");
		
		[Test]
		public void Update_telephone()
			=> Church.Factory.CreateNew("nome", "foto"
				, Email.Factory.CreateNew("scorponok@scorponok.com")
				, Telephone.Factory.CreateNew(55, 21, "987413955")
				, Address.Factory.Empty())
				.UpdateTelephone("987413988")
			.Telephone
			.Numero
			.Should()
			.Be("987413988");
		
		[Ignore("Not implement")]
		public void Update_address()
			=> Church.Factory.CreateNew("nome", "foto"
				, Email.Factory.CreateNew("scorponok@scorponok.com")
				, Telephone.Factory.CreateNew(55, 21, "987413955")
				, Address.Factory.Empty())
				.UpdateAddress("xxxxxxx")
			.Address.Should()
			.Be(Address.Factory.Empty());
	}
}