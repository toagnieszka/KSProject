
namespace KSProject.BackgroundServiceEx
{
	public class CustomOperation : IBackgroundOperation
	{
		public async Task Run(CancellationToken cancellationToken)
		{
			//symulacja
			Console.WriteLine("custom operation started...");
			await Task.Delay(500, cancellationToken);
			Console.WriteLine("custom operation completed...");
		}
	}
}
