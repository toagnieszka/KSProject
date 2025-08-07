using KSProject.ValueObjects;

namespace KSProject.Models
{
	public record Appointment(Guid Id, Slot Slot, Guid? PatientId, Guid DoctorId) : BasicResource;
}
