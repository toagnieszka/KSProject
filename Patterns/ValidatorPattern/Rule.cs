using KSProject.Patterns.SpecificationPattern;

namespace KSProject.Patterns.ValidatorPattern
{
	public class Rule<T> where T : class
	{
		public ISpecification<T> Specification;

		public Rule(ISpecification<T> specification)
		{
			Specification = specification;
		}
	}
}
