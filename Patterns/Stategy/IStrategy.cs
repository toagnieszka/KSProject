using KSProject.Models;
using KSProject.Patterns.CQRS.Commands;

namespace KSProject.Patterns.Stategy
{
	public interface IStrategy
	{
		bool IsValid();
		Person Create(Guid id, string name, string surname, string? pesel, string? age, string? insuranceNumber, string? specialization, string? medicalLicense);
		bool CanHandle(RegisterPersonCommand command);
	}
}
