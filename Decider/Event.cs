namespace KSProject.Decider
{
	public abstract record Event(Guid AppointmentId, DateTime OccuredAt)
	{
		public record Created(Guid AppointmentId, Guid DoctorId, DateTime Start, DateTime End, DateTime OccuredAt) : Event(AppointmentId, OccuredAt); 
		public record Booked(Guid AppointmentId, Guid PatientId, DateTime OccuredAt) : Event(AppointmentId, OccuredAt);
		public record Canceled(Guid AppointmentId, DateTime OccuredAt) : Event(AppointmentId, OccuredAt);
	}
}
