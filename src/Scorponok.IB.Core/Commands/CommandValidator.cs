using FluentValidation;

namespace Scorponok.IB.Core.Commands
{
	public abstract class CommandValidator<T> : AbstractValidator<T> where T : Command
	{
		
	}
}