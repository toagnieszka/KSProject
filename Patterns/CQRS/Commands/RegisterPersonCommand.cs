namespace KSProject.Patterns.CQRS.Commands
{
	public record RegisterPersonCommand(
	Guid Id,
	string Name,
	string Surname,
	string? Pesel = null,
	string? Age = null,
	string? InsuranceNumber = null,
	string? Specialization = null,
	string? MedicalLicense = null
	);
}
