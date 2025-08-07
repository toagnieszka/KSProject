using Azure.Storage.Blobs;
using Azure;

namespace KSProject.Services
{
	public class BlobUploadService : IBlobUploadService
	{
		private readonly BlobServiceClient blobServiceClient;

		public BlobUploadService(BlobServiceClient blobServiceClient)
		{
			this.blobServiceClient = blobServiceClient;
		}

		public async Task Upload(string containerKey, IFormFile file)
		{
			var containerName = $"container-{containerKey.ToLower()}";
			var blobName = file.FileName;

			var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
			var blobClient = containerClient.GetBlobClient(blobName);

			try
			{
				using var stream = file.OpenReadStream();
				await blobClient.UploadAsync(stream, overwrite: true);
			}
			catch (RequestFailedException ex) when (ex.ErrorCode == "ContainerNotFound")
			{
				await containerClient.CreateAsync();
				using var stream = file.OpenReadStream();
				await blobClient.UploadAsync(stream, overwrite: true);
			}
		}
	}
}
