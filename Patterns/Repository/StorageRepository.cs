using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using KSProject.Models;
using System.Text;
using System.Text.Json;

namespace KSProject.Patterns.Repository
{
	public class StorageRepository : IRepository
	{
		private readonly BlobServiceClient client;
		private readonly string container;

		public StorageRepository(string connectionString, string container)
		{
			this.container = container;
			client = new BlobServiceClient(connectionString);
		}

		public async Task<T> Get<T>(Guid id) where T : class, IRepositoryObject
		{
			var cont = client.GetBlobContainerClient(container);
			var blobClient = cont.GetBlobClient($"{id}.json");

			try
			{
				BlobDownloadResult result = await blobClient.DownloadContentAsync();
				var content = result.Content.ToString();
				return JsonSerializer.Deserialize<T>(content)
					?? throw new Exception("Failed serialization");
			}
			catch (Exception) { throw; }
		}

		public async Task Save<T>(T input) where T : class, IRepositoryObject
		{
			var cont = client.GetBlobContainerClient(container);
			var data = JsonSerializer.Serialize(input);
			using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
			await cont.UploadBlobAsync($"{input.Id}.json", stream);
		}
	}
}
