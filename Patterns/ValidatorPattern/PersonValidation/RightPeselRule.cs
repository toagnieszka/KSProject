using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.SpecificationPattern;

namespace KSProject.Patterns.ValidatorPattern.PersonValidation
{
	public class RightPeselRule : ISpecification<RegisterPersonCommand>
	{
		public bool IsSatisfiedBy(RegisterPersonCommand command) => command.Pesel.ToCharArray().Length == 11;
	}
}
