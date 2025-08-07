using KSProject.Patterns.Repository;
using System.Text.Json.Serialization;

namespace KSProject.Models
{
	[JsonDerivedType(typeof(Patient), "Patient")]
	[JsonDerivedType(typeof(Doctor), "Doctor")]
	public abstract record Person(Guid Id) : IRepositoryObject
    {
	};
}

