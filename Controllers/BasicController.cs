using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using KSProject.Patterns;

namespace KSProject.Controllers
{
	public record PersonRequest(Guid Id, string Name, string Surname, string Pesel = null, string Age = null, string InsuranceNumber = null, string Specialization = null, string MedicalLicense = null);

	[ApiController]
	[Route("[controller]")]
	public class BasicController
	{
		private readonly IRepository _repository;

		public BasicController(IRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return new OkObjectResult("Hello world");
		}


		[HttpPost(Name = "Persons")]
		public async Task<IResult> Create(PersonRequest request)
		{
			var mapper = new PersonRequestMapper();
			var person = mapper.Map(request);
			await _repository.Save(person);
			return Results.Ok();
		}
	}
}
