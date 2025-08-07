namespace KSProject.Models
{
	public record Patient(Guid Id, string Name, string Surname, string Pesel, string Age, string InsuranceNumber) : Person(Id);
}
