using System;
using FluentValidation.Results;
using Scorponok.IB.Core.Events;

namespace Scorponok.IB.Core.Commands
{
	public abstract class Command : Message
	{
		public DateTime Timestamp
		{
			get;
			private set;
		}

		public ValidationResult ValidationResult { get; set; }

		public Command()
		{
			this.Timestamp = new DateTime();
		}

		public abstract bool IsValid();
	}
}
