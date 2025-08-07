using KSProject.Models;
using KSProject.Patterns.CQRS.Commands;

namespace KSProject.Patterns.Stategy
{
	public class StrategyPatientPerson : IStrategy
	{
		public bool CanHandle(RegisterPersonCommand command)
		=> !string.IsNullOrEmpty(command.Pesel);

		public Person Create(Guid id, string name, string surname, string pesel, string age, string insuranceNumber, string? specialization, string? medicalLicense)
		{
			return new Patient(id, name, surname, pesel, age, insuranceNumber);
		}

		public bool IsValid()
		{
			return true;
		}

	}
}
