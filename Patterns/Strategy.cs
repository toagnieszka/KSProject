using KSProject.Models;


namespace KSProject.Patterns

{
    public interface IStrategy
    {
        bool IsValid();
        Person Create(Guid id, string name, string surname, string? pesel, string? age, string? insuranceNumber, string? specialization, string? medicalLicense);
    }

   

    public class StrategyPateientPerson : IStrategy
    {
        public Person Create(Guid id, string name, string surname, string? pesel, string? age, string? insuranceNumber, string? specialization, string? medicalLicense)
        {
            return new Person.Patient(id, name, surname, pesel, age, insuranceNumber);
        }

        public bool IsValid()
        {
            return true;
        }

    }

    public class StrategyDoctorPerson : IStrategy
    {
        public Person Create(Guid id, string name, string surname, string? pesel, string age, string? insuranceNumber, string? specialization, string? medicalLicense)
        {
            return new Person.Doctor(id, name, surname, specialization, medicalLicense);
        }

        public bool IsValid()
        {
            return true;
        }

    }
}

