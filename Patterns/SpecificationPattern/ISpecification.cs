namespace KSProject.Patterns.SpecificationPattern
{
	public interface ISpecification<T> where T : class
	{
		bool IsSatisfiedBy(T input);
	}
}
