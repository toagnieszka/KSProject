using KSProject.Models;
using System.Text.Json.Serialization;

namespace KSProject.DTOs
{
	public record PersonDto(
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
