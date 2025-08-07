using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.Stategy;
using KSProject.Patterns.ValidatorPattern;

namespace KSProject.Patterns.ChainOfResponsibility
{
	public class ValidationChainFactory
	{
		private readonly Validator<RegisterPersonCommand> _validator;

		public ValidationChainFactory(Validator<RegisterPersonCommand> validator)
		{
			_validator = validator;
		}

		private IHandle<RegisterPersonCommand> Chain(params Func<IHandle<RegisterPersonCommand>, IHandle<RegisterPersonCommand>>[] handlers) 
		{
			IHandle<RegisterPersonCommand> current = new ValidationExecutorHandler(_validator);

			foreach (var builder in handlers.Reverse())
			{
				current = builder(current);
			}

			return current;
		}

		public IHandle<RegisterPersonCommand> Create(IStrategy strategy)
		{
			if (strategy is StrategyDoctorPerson)
			{
				return Chain(
					next => new SpecializationHandler(next, _validator),
					next => new SurnameHandler(next, _validator)
				);
			}

			if (strategy is StrategyPatientPerson)
			{
				return Chain(
					next => new PeselHandler(next, _validator),
					next => new SurnameHandler(next, _validator)
				);
			}

			throw new InvalidOperationException("Unsupported person type.");
		}
	}
}
