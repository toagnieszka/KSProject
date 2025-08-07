using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;

namespace KSProject.ServiceBus
{
	public class ServiceBusManager : IHostedService
	{
		private readonly ServiceBusClient sbClient;
		private readonly ServiceBusProcessor sbProcessor;

		public ServiceBusManager(IAzureClientFactory<ServiceBusClient> clientFactory)
		{
			sbClient = clientFactory.CreateClient("sbClient");
			sbProcessor = sbClient.CreateProcessor("queue-agnieszka", new ServiceBusProcessorOptions
			{
				MaxConcurrentCalls = 5,
				AutoCompleteMessages = false
			});
			sbProcessor.ProcessMessageAsync += SbProcessor_ProcessMessageAsync;
			sbProcessor.ProcessErrorAsync += SbProcessor_ProcessErrorAsync;
		}

		private async Task SbProcessor_ProcessMessageAsync(ProcessMessageEventArgs args) 
		{
			string body = args.Message.Body.ToString();
			Console.WriteLine($"Received message: {body}");
		}

		private async Task SbProcessor_ProcessErrorAsync(ProcessErrorEventArgs args)
		{
			Console.WriteLine($"Service Bus Error: {args.Exception.Message}");
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await sbProcessor.StartProcessingAsync(cancellationToken);
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			await sbProcessor.StopProcessingAsync(cancellationToken);
		}
	}
}

