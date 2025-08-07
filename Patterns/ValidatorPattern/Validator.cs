namespace KSProject.Patterns.ValidatorPattern
{
	public class Validator<T> where T : class
	{
		private List<Rule<T>> rules = new();

		public Validator<T> Add(Rule<T> rule)
		{
			rules.Add(rule);
			return this;
		}

		public T Execute(T input)
		{
			foreach (var rule in rules)
			{
				if (rule.Specification.IsSatisfiedBy(input) == false)
				{
					throw new Exception($"Validation failed for rule: {rule.GetType().Name}");
				}
			}
			return input;//TODo zastosowanie, dwie reguly do zastosowania klasy/dwa przyklady walidatora i jak sie to bedzie chainować/protip: dwie klasy z 1 metoda
		}
	}
}
