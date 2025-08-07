using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.ValidatorPattern.PersonValidation;
using KSProject.Patterns.ValidatorPattern;

namespace KSProject.Patterns.ChainOfResponsibility
{
	public class SpecializationHandler : IHandle<RegisterPersonCommand>
	{
		private readonly IHandle<RegisterPersonCommand> _next;
		private readonly Validator<RegisterPersonCommand> _validator;

		public SpecializationHandler(IHandle<RegisterPersonCommand> next, Validator<RegisterPersonCommand> validator)
		{
			_next = next;
			_validator = validator;
		}

		public async Task Handle(RegisterPersonCommand input)
		{
			_validator.Add(new Rule<RegisterPersonCommand>(new SpecializationIsNotEmptyRule()));
			await _next.Handle(input);
		}
	}
}
