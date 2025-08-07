using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KSProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KSProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UploadFileController : ControllerBase
	{
		private readonly IBlobUploadService _blobUploadService;

		public UploadFileController(IBlobUploadService blobUploadService)
		{
			_blobUploadService = blobUploadService;
		}

		[HttpPost("{containerKey}/upload")]
		public async Task<ActionResult<string>> Upload(string containerKey, IFormFile file)
		{
			if (file is null || file.Length == 0)
				return BadRequest("The file is empty");

			await _blobUploadService.Upload(containerKey, file);

			return Ok("File was successfully sent to the container");
		}
	}
}
