using KSProject.Patterns;

namespace KSProject.Models
{
    public abstract record Person : IRepositoryObject
    {
		public record Patient(Guid Id, string Name, string Surname, string Pesel, string Age, string InsuranceNumber) : Person;

		public record Doctor(Guid Id, string Name, string Surname, string Specialization, string MedicalLicense) : Person;
	};

    
}

