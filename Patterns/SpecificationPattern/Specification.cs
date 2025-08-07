namespace KSProject.Patterns.SpecificationPattern
{
	public abstract class Specification<T> : ISpecification<T> where T : class
	{
		public abstract bool IsSatisfiedBy(T input);

		public Specification<T> And(Specification<T> other)
		{
			return new AndSpecification<T>(this, other);
		}
		public Specification<T> Or(Specification<T> other)
		{
			return new OrSpecification<T>(this, other);
		}
		public Specification<T> Not()
		{
			return new NotSpecification<T>(this);
		}
	}
}
