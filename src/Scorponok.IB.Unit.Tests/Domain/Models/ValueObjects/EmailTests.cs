using FluentAssertions;
using NUnit.Framework;
using Scorponok.IB.Core.ValueObjects;

namespace Scorponok.IB.Unit.Tests.Domain.Models.ValueObjects
{
	[TestFixture, Category("Domain/Organizacoes/ValueObjects")]
	public class EmailTests
	{
		[TestCase("a@teste.com.br")]
		[TestCase("a@cd.com")]
		[TestCase("a1@teste.com.br")]
		[TestCase("222222@12333.com")]
		public void Deve_validar_email_com_sucesso(string value)
		{
			var email = Email.Factory.CreateNew(value);

			email.Should().NotBeNull();
			email.Valido.Should().BeTrue();
		}

		[TestCase("a@teste.com.br", "a@teste.com.br")]
		[TestCase("a@cd.com", "a@cd.com")]
		[TestCase("a1@teste.com.br", "a1@teste.com.br")]
		[TestCase("222222@12333.com", "222222@12333.com")]
		public void Deve_entender_as_duas_instancias_de_email_com_sucesso(string value1, string value2)
		{
			var email1 = Email.Factory.CreateNew(value1);
			var email2 = Email.Factory.CreateNew(value2);

			email1.Should().NotBeNull();
			email2.Valido.Should().BeTrue();

			email1.Equals(email2).Should().BeTrue();
			
		}

		[TestCase("a@teste.com.br", "a@gmail.com.br")]
		[TestCase("a@cd.com", "aaass@outro.com.br")]
		[TestCase("a1@teste.com.br", "a1@teste2.com.br")]
		[TestCase("222222@12333.com", "222222@aaaaa.com")]
		public void Deve_entender_as_instancias_de_email_sao_diferentes_com_sucesso(string value1, string value2)
		{
			var email1 = Email.Factory.CreateNew(value1);
			var email2 = Email.Factory.CreateNew(value2);

			email1.Should().NotBeNull();
			email2.Valido.Should().BeTrue();

			email1.Equals(email2).Should().BeFalse();
		}

		[TestCase("a@XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.com.br")]
		public void Deve_validar_o_tamanho_maximo_do_email_com_sucesso(string value)
		{
			var email = Email.Factory.CreateNew(value);

			email.Should().NotBeNull();
			email.Valido.Should().BeFalse();
			email.Mensagem.Should().Be($"E-mail: {email.Value} informado ultrapassou a quantidade permitida de {Email.EMAIL_MAX_LENGTH}");
		}

		[TestCase("a@x")]
		public void Deve_validar_o_tamanho_minimo_do_email_com_sucesso(string value)
		{
			var email = Email.Factory.CreateNew(value);

			email.Should().NotBeNull();
			email.Valido.Should().BeFalse();
			email.Mensagem.Should().Be($"E-mail: {email.Value} informado não possui a quantidade mínima permitida de {Email.EMAIL_MIN_LENGTH}");
		}


		[TestCase("fully-qualified-domain@example.com.")]
		[TestCase("    @example.com.")]
		[TestCase("$#$%%%%%@example.com.")]
		[TestCase("xxx ~ não tem @")]
		public void Deve_validar_email_invalido_com_sucesso(string value)
		{
			var email = Email.Factory.CreateNew(value);

			email.Should().NotBeNull();
			email.Valido.Should().BeFalse();
			email.Mensagem.Should().Be($"E-mail: {email.Value} inváido");
		}
	}
}