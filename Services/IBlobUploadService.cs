namespace KSProject.Services
{
	public interface IBlobUploadService
	{
		Task Upload(string containerKey, IFormFile file);
	}
}
