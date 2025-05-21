using KSProject.Patterns;

namespace KSProject.Decider
{
	public class DeciderManager
	{
		private List<Event> _eventStore = new();

		public event EventHandler? ItemBooked;
		public event EventHandler? ItemCanceled;

		public SlotState CurrentState => _eventStore.Fold(); // wykorzystuje Decidera

		public Result BookSlot(DateTime start, DateTime end)
		{
			var state = CurrentState;
			if (state is SlotState.Booked)
				return Result.Failure(new Error("Slot.Booked", "You can't book an event for this date"));

			var events = state.Decide(new Command.Create(start, end));
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
			ItemBooked += EventBooked;
			ItemCanceled += EventCanceled;
		}
	}
}
