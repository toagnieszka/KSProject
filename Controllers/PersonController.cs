using KSProject.DTOs;
using KSProject.Models;
using KSProject.Patterns.CQRS.Commands;
using KSProject.Patterns.CQRS.Queries;
using KSProject.Patterns.Mapper;
using KSProject.Patterns.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KSProject.Controllers
{
	public class PersonController : ControllerBase
	{
		private readonly ICommandHandler<RegisterPersonCommand> commandHandler;
		private readonly IQueryHandler<GetPersonQuery, PersonDto> queryHandler;

		public PersonController(ICommandHandler<RegisterPersonCommand> commandHandler, IQueryHandler<GetPersonQuery, PersonDto> queryHandler)
		{
			this.commandHandler = commandHandler;
			this.queryHandler = queryHandler;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PersonDto>> Get(Guid id)
		{
			var personDto = await queryHandler.Handle(new GetPersonQuery(id));
			return Ok(personDto);
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] RegisterPersonCommand commmand)
		{
			await commandHandler.Handle(commmand);//kolejka????
			return Ok();
		}
	}
}
