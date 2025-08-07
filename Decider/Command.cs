namespace KSProject.Decider
{
	public abstract record Command
	{
		public record Create(Guid AppointmentId, Guid DoctorId, DateTime Start, DateTime End) : Command;
		public record Book(Guid PatientId) : Command;
		public record Cancel : Command;
	}
}
