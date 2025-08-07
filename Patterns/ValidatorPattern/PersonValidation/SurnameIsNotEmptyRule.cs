using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.SpecificationPattern;

namespace KSProject.Patterns.ValidatorPattern.PersonValidation
{
	public class SurnameIsNotEmptyRule : ISpecification<RegisterPersonCommand>
	{
		public bool IsSatisfiedBy(RegisterPersonCommand command) => !string.IsNullOrEmpty(command.Surname);
	}
}
