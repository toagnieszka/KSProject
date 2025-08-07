using KSProject.Patterns.ResultPattern;
using static KSProject.Decider.Command;

namespace KSProject.Decider
{
    public class DeciderManager
	{
		private List<Event> _eventStore = new();

		public event EventHandler? ItemCreated;
		public event EventHandler? ItemBooked;
		public event EventHandler? ItemCanceled;

		public SlotState CurrentState => Decider.Fold(_eventStore); // wykorzystuje Decidera

		public void InitSlot(Guid appointmentId, Guid doctorId, DateTime start, DateTime end)
		{
			var state = CurrentState;
			var events = state.Decide(new Create(appointmentId, doctorId, start, end));
			_eventStore.AddRange(events);
			ItemCreated.Invoke(this, new EventArgs());
		}

		public Result BookSlot(Guid patientId)
		{
			var state = CurrentState;
			if (state is SlotState.Booked)
				return Result.Failure(new Error("Slot.Booked", "You can't book an event for this date"));

			var events = state.Decide(new Book(patientId));
			_eventStore.AddRange(events);
			ItemBooked.Invoke(this, new EventArgs());
			return Result.Success();
		}

		public Result CancelSlot()
		{
			var state = CurrentState;
			if (state is not SlotState.Booked)
				return Result.Failure(new Error("Slot.Free", "You can't cancel this event"));

			var events = state.Decide(new Command.Cancel());
			_eventStore.AddRange(events);
			ItemCanceled.Invoke(this, new EventArgs());
			return Result.Success();
		}

		private static void EventCreated(object sender, EventArgs args)
		{
			Console.WriteLine("Event was created");
		}
		private static void EventBooked(object sender, EventArgs args)
		{
			Console.WriteLine("Event was booked");
		}

		private static void EventCanceled(object sender, EventArgs args)
		{
			Console.WriteLine("Event was canceled");
		}

		public void UseEvents()
		{
			ItemCreated += EventCreated;
			ItemBooked += EventBooked;
			ItemCanceled += EventCanceled;
		}
	}
}
