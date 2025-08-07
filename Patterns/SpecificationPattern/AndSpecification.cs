namespace KSProject.Patterns.SpecificationPattern
{
	public class AndSpecification<T> : Specification<T> where T : class
	{
		private readonly Specification<T> left;
		private readonly Specification<T> right;

		public AndSpecification(Specification<T> left, Specification<T> right)
		{
			this.left = left;
			this.right = right;
		}

		public override bool IsSatisfiedBy(T input)
		{
			return left.IsSatisfiedBy(input) && right.IsSatisfiedBy(input);
		}
	}
}
