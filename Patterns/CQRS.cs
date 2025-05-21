namespace KSProject.Patterns
{
	public interface ICommandHandler<in T>
	{
		public Task Handle(T command);
	}

	public interface IQuery<in TQuery, TResult>
	{
		public Task<TResult> Handle(TQuery query);
	}
	public record RegisterPatientCommand(Guid Id, string Name, string Surname);

	public record GetPatientQuery(Guid Id);

	public class ExampleCommandHandler : ICommandHandler<RegisterPatientCommand>
	{
		public Task Handle(RegisterPatientCommand command)
		{
			Console.WriteLine($"Rejestruję pacjenta {command.Name} {command.Surname} z ID {command.Id}");
			return Task.CompletedTask;
		}
	}

	public class ExampleQueryHandler : IQuery<GetPatientQuery, string>
	{
		public Task<string> Handle(GetPatientQuery query)
		{
			return Task.FromResult($"Pacjent o ID: {query.Id}");
		}
	}
}
