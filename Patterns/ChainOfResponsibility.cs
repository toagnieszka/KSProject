namespace KSProject.Patterns
{
	public interface IHandle<T>
	{
		public Task Handle(T input);
	}

	public class HandleOne : IHandle<string>
	{
		private readonly IHandle<string> _next;
		public HandleOne(IHandle<string> next) 
		{
			_next = next;
		}

		public async Task Handle(string input)
		{
			Console.WriteLine($"Handle one: {input}");
			await _next.Handle(input);
		}

		public class HandleTwo : IHandle<string>
		{
			private readonly IHandle<string> _next;
			public HandleTwo(IHandle<string> next)
			{
				_next = next;
			}

			public async Task Handle(string input)
			{
				Console.WriteLine($"Handle two: {input}");
				await _next.Handle(input);
			}
		}

		public class HandleThree : IHandle<string>
		{
			public async Task Handle(string input)
			{
				Console.WriteLine($"Handle three: {input}");
				await Task.CompletedTask;
			}
		}
	}
}
