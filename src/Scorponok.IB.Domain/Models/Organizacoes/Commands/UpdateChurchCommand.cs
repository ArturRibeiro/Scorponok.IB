using System;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Organizacoes.Commands
{
	public class UpdateChurchCommand : Command
	{
		#region Propriedades
		public Guid Id { get; }
		public string Name { get; }
		public string Photo { get; }
		public string Email { get; }
		public byte DDD { get; }
		public string Telephone { get; }
		#endregion

		public UpdateChurchCommand(Guid id, string name, string photo, string email, string telephone)
		{
			Id = id;
			Name = name;
			Photo = photo;
			Email = email;
			Telephone = telephone;
		}

		public override bool IsValid()
			=> true;

	}
}