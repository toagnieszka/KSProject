namespace KSProject.Patterns.ChainOfResponsibility
{
	public interface IHandle<T> where T : class
	{
		public Task Handle(T input);
	}
}
