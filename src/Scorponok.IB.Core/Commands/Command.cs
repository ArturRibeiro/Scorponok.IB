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
		}

		public ValidationResult ValidationResult { get; set; }

	    protected Command() => this.Timestamp = new DateTime();

		public abstract bool IsValid();
	}
}
