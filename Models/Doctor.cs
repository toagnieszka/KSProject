namespace KSProject.Models
{
	public record Doctor(Guid Id, string Name, string Surname, string Specialization, string MedicalLicense) : Person(Id);
}
