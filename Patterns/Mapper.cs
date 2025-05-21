using KSProject.Models;
using KSProject.Controllers;
using System.Xml.Linq;

namespace KSProject.Patterns;

public interface IMapper<in Input, out Output> where Input : class where Output : class
{
	public Output Map(Input input);
}

public class PersonRequestMapper : IMapper<PersonRequest, Person>
{
	public Person Map(PersonRequest input)
	{
		if (string.IsNullOrEmpty(input.Pesel) && string.IsNullOrEmpty(input.Age) && string.IsNullOrEmpty(input.InsuranceNumber))
			return new Person.Doctor(input.Id, input.Name, input.Surname, input.Specialization, input.MedicalLicense);
		else
			return new Person.Patient(input.Id, input.Name, input.Surname, input.Pesel, input.Age, input.InsuranceNumber);
	}
}

