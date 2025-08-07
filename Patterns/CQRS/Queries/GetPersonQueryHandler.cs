using KSProject.DTOs;
using KSProject.Models;
using KSProject.Patterns.Mapper;
using KSProject.Patterns.Repository;

namespace KSProject.Patterns.CQRS.Queries
{
	public class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonDto>
	{
		private readonly IRepository repository;

		public GetPersonQueryHandler(IRepository repository)
		{
			this.repository = repository;
		}

		public async Task<PersonDto> Handle(GetPersonQuery query)
		{
			var person = await repository.Get<Person>(query.Id);
			var mapper = new PersonDtoRequestMapper();
			var personDto = mapper.Map(person);
			return personDto;
		}
	}
}
