namespace KSProject.BackgroundServiceEx
{
	public interface IBackgroundOperation
	{
		Task Run(CancellationToken cancellationToken);
	}
}
