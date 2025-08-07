using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.ValidatorPattern;
using KSProject.Patterns.ValidatorPattern.PersonValidation;

namespace KSProject.Patterns.ChainOfResponsibility
{
	public class SurnameHandler : IHandle<RegisterPersonCommand>
	{
		private readonly IHandle<RegisterPersonCommand> _next;
		private readonly Validator<RegisterPersonCommand> _validator;

		public SurnameHandler(IHandle<RegisterPersonCommand> next, Validator<RegisterPersonCommand> validator)
		{
			_next = next;
			_validator = validator;
		}

		public async Task Handle(RegisterPersonCommand input)
		{
			_validator.Add(new Rule<RegisterPersonCommand>(new SurnameIsNotEmptyRule()));
			await _next.Handle(input);
		}
	}
}

