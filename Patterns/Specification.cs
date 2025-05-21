using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KSProject.Patterns
{
	public interface ISpecification<T> where T: class
	{
		bool IsSatisfiedBy(T input);
	}
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
		public Specification<T> Not(Specification<T> other)
		{
			return new NotSpecification<T>(this, other);
		}
	}
	
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

	public class OrSpecification<T> : Specification<T> where T : class
	{
		private readonly Specification<T> left;
		private readonly Specification<T> right;

		public OrSpecification(Specification<T> left, Specification<T> right)
		{
			this.left = left;
			this.right = right;
		}

		public override bool IsSatisfiedBy(T input)
		{
			return left.IsSatisfiedBy(input) || right.IsSatisfiedBy(input);
		}
	}

	public class NotSpecification<T> : Specification<T> where T : class
	{
		private readonly Specification<T> left;
		private readonly Specification<T> right;

		public NotSpecification(Specification<T> left, Specification<T> right)
		{
			this.left = left;
			this.right = right;
		}

		public override bool IsSatisfiedBy(T input)
		{
			return left.IsSatisfiedBy(input) != right.IsSatisfiedBy(input);
		}
	}


	public class Rule<T> where T : class
	{
		public ISpecification<T> Specification;

		public Rule(ISpecification<T> specification)
		{
			Specification = specification;
		}
	}

	public abstract class Validator<T> where T : class
	{
		private List<Rule<T>> rules = new();

		public Validator<T> Add(Rule<T> rule)
		{
			rules.Add(rule);
			return this;
		}

		public T Execute(T input)
		{
			foreach(var rule in rules)
			{
				if(rule.Specification.IsSatisfiedBy(input) == false)
				{
					throw new Exception("Validation failed");
				}
			}
			return input;//TODo zastosowanie, dwie reguly do zastosowania klasy/dwa przyklady walidatora i jak sie to bedzie chainować/protip: dwie klasy z 1 metoda
		}
	}
}
