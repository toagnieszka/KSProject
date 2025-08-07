namespace KSProject.Patterns.Observer
{
	public abstract class Publisher
	{
		public event EventHandler Handler;
		public void Publish(EventArgs args)
		{
			Handler?.Invoke(this, args);
		}
	}
}
