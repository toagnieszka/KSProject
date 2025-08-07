using KSProject.ValueObjects;

namespace KSProject.Models
{
	public record Visit(Guid Id, Slot Slot, Patient Patient, Guid PatientId, Doctor Doctor, Guid DoctorId) : BasicResource;
}
