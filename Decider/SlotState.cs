namespace KSProject.Decider
{
	public abstract record SlotState
	{
		public sealed record Initial : SlotState;
		public sealed record Free(Guid AppointmentId, Guid DoctorId, DateTime Start, DateTime End) : SlotState;
		public sealed record Booked(Guid AppointmentId, Guid DoctorId, Guid PatientId, DateTime Start, DateTime End) : SlotState;
	}
}
