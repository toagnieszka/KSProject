using KSProject.Patterns.CQRS.Commands;

namespace KSProject.Patterns.Stategy
{
	public class StrategySelector
	{
		private readonly IEnumerable<IStrategy> _strategies;

		public StrategySelector(IEnumerable<IStrategy> strategies)
		{
			_strategies = strategies;
		}

		public IStrategy? Select(RegisterPersonCommand command)
		{
			foreach (var strategy in _strategies)
			{
				if(strategy.CanHandle(command))
					return strategy;
			}
			return null;
		}
	}
}
