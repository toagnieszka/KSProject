using KSProject.DTOs;
using KSProject.Models;

namespace KSProject.Patterns.Mapper
{
	public class PersonDtoRequestMapper : IMapper<Person, PersonDto>
	{
		public PersonDto Map(Person input)
		{
			if(input is Doctor doctor)
				return new PersonDto(doctor.Id, doctor.Name, doctor.Surname, doctor.Specialization, doctor.MedicalLicense);
			else if(input is Patient patient)
				return new PersonDto(patient.Id, patient.Name, patient.Surname, patient.Pesel, patient.Age, patient.InsuranceNumber);

			throw new ArgumentException("Unknown Person type", nameof(input));
		}
	}
}
