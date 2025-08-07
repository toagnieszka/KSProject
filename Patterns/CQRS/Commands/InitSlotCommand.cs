namespace KSProject.Patterns.CQRS.Commands
{
	public record InitSlotCommand(Guid AppointmentId, Guid DoctorId, DateTime Start, DateTime End);
}
