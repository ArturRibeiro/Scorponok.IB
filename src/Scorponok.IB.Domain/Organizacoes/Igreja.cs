namespace Scorponok.IB.Domain.Organizacoes
{
	public class Igreja
	{
		#region Propriedades
		public string Nome { get; private set; }
		public string Foto { get; private set; }
		//public Email Email { get; private set; }
		//public Telefone Telefone { get; private set; }
		#endregion

		#region Factor
		//public static class Factory
		//{
		//	public static Igreja Create(string nome, string foto, Email email, Telefone telefone, IgrejaEndereco endereco)
		//	{
		//		return new Igreja(nome, foto, email, telefone, endereco);
		//	}

		//	public static Igreja Create(string nome, string foto, Email email, Telefone telefone)
		//	{
		//		return new Igreja(nome, foto, email, telefone);
		//	}
		//}
		#endregion
	}
}