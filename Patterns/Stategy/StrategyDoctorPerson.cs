using KSProject.Models;
using KSProject.Patterns.CQRS.Commands;

namespace KSProject.Patterns.Stategy
{
    public class StrategyDoctorPerson : IStrategy
    {
		public bool CanHandle(RegisterPersonCommand command)
		=> !string.IsNullOrEmpty(command.Specialization);

		public Person Create(Guid id, string name, string surname, string? pesel, string age, string? insuranceNumber, string specialization, string medicalLicense)
        {
            return new Doctor(id, name, surname, specialization, medicalLicense);
        }

        public bool IsValid()
        {
            return true;
        }
    }
}

