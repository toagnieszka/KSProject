using KSProject.Models;
using KSProject.Patterns.Stategy;

namespace KSProject.Patterns
{
	public class PersonBuilder
	{
		private Guid id;
		private string name = "";
		private string surname = "";
		private string? pesel = null;
		private string? age = null;
		private string? insuranceNumber = null;
		private string? specialization = null;
		private string? medlicalLicense = null;
		private IStrategy strategy;

		public PersonBuilder SetId(Guid id)
		{
			this.id = id;
			return this;
		}

		public PersonBuilder SetName(string name)
		{
			this.name = name;
			return this;
		}

		public PersonBuilder SetSurname(string surname)
		{
			this.surname = surname;
			return this;
		}

		public PersonBuilder SetPesel(string pesel)
		{
			this.pesel = pesel;
			return this;
		}

		public PersonBuilder SetAge(string age)
		{
			this.age = age;
			return this;
		}

		public PersonBuilder SetInsuranceNumber(string insuranceNumber)
		{
			this.insuranceNumber = insuranceNumber;
			return this;
		}

		public PersonBuilder SetSpecialization(string specialization)
		{
			this.specialization = specialization;
			return this;
		}

		public PersonBuilder SetMedlicalLicense(string medlicalLicense)
		{
			this.medlicalLicense = medlicalLicense;
			return this;
		}

		public PersonBuilder UseStrategy(IStrategy strategy)
		{
			this.strategy = strategy;
			return this;
		}

		public Person Build()
		{
			//TODO: użycie odpowiedniej polityki

			if (strategy is null)
			{
				throw new Exception("No valid strategy for the given data");
			}
			var person = strategy.Create(id, name, surname, pesel, age, insuranceNumber, specialization, medlicalLicense);
			return person;
		}
	}
}
