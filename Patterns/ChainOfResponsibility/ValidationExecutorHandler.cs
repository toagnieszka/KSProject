using KSProject.Models;
using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.ValidatorPattern;

namespace KSProject.Patterns.ChainOfResponsibility
{
	public class ValidationExecutorHandler : IHandle<RegisterPersonCommand>
	{
		private readonly Validator<RegisterPersonCommand> _validator;

		public ValidationExecutorHandler(Validator<RegisterPersonCommand> validator)
		{
			_validator = validator;
		}

		public async Task Handle(RegisterPersonCommand input)
		{
			_validator.Execute(input);
			Console.WriteLine($"Validation processed successfully!");
			await Task.CompletedTask;
		}
	}
}

