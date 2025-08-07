using Microsoft.Extensions.Hosting;

namespace KSProject.BackgroundServiceEx
{
	public class BackgroundServiceExample<T>(T operation) : BackgroundService where T : class, IBackgroundOperation
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while(stoppingToken.IsCancellationRequested == false)
			{
				await operation.Run(stoppingToken);
			}
		}
	}
}
