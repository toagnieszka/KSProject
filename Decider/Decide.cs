using KSProject.Patterns;
using System.Collections.Concurrent;

namespace KSProject.Decider
{
	public static class Decider
	{
		private static ConcurrentQueue<Event> events = new();

		public static SlotState Fold(this IEnumerable<Event> events, SlotState state) => events.Aggregate(state, Evolve); //odtwarzam historie zdarzeń(daje mu kolekcje eventów i odtwarzam slotState po kolei co się działo)
		public static SlotState Fold(this IEnumerable<Event> events) => events.Fold(new SlotState.Initial()); //przy initial nie ma jeszcze żadnej historii

		public static SlotState Evolve(SlotState state, Event ev) => //ewolucja stanu -> jak zdarzenie wpływa na stan
			(state, ev) switch
			{
				(SlotState.Initial, Event.Created evc) => new SlotState.Free(evc.AppointmentId, evc.DoctorId, evc.Start, evc.End),
				(SlotState.Free ssf, Event.Booked evb) => new SlotState.Booked(ssf.AppointmentId, ssf.DoctorId, evb.PatientId, ssf.Start, ssf.End),
				(SlotState.Booked ssb, Event.Canceled evb) => new SlotState.Free(ssb.AppointmentId, ssb.DoctorId, ssb.Start, ssb.End),
				_ => state
			};

		public static IEnumerable<Event> Decide(this SlotState state, Command command) =>
			(state, command) switch
			{
				(SlotState.Initial, Command.Create c) => Create(c.AppointmentId, c.DoctorId, c.Start, c.End),
				(SlotState.Free, Command.Book b) => Book(b.PatientId),
				(SlotState.Booked, Command.Cancel) => Cancel(),
				_ => throw new InvalidOperationException($"Command {command.GetType().Name} cannot be applied")
			};

		public static IEnumerable<Event> Create(Guid AppointmentId, Guid DoctorId, DateTime Start, DateTime End)
		{
			var ev = new Event.Created(AppointmentId, DoctorId, Start, End, DateTime.UtcNow);
			events.Enqueue(ev);
			return events;
		}
		public static IEnumerable<Event> Book(Guid PatientId)
		{
			var ev = new Event.Booked(Guid.NewGuid(), PatientId, DateTime.UtcNow);
			events.Enqueue(ev);
			return events;
		}
		public static IEnumerable<Event> Cancel()
		{
			var ev = new Event.Canceled(Guid.NewGuid(), DateTime.UtcNow);
			events.Enqueue(ev);
			//?????return new[] { ev };
			return events;
		}
	}
}
//TO uzywcie validatora, (decidera), (dopisac specification), (dopisac Qeuryhandlera), (uzycie observera)
