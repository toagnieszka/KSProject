using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KSProject.Patterns.SpecificationPattern
{
    public class NotSpecification<T> : Specification<T> where T : class
    {
        private readonly Specification<T> inner;

        public NotSpecification(Specification<T> inner)
        {
            this.inner = inner;
        }

        public override bool IsSatisfiedBy(T input)
        {
            return !inner.IsSatisfiedBy(input);
		}
    }
}
