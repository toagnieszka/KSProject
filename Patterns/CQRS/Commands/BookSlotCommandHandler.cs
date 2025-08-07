using KSProject.Decider;
using KSProject.Patterns.ResultPattern;

namespace KSProject.Patterns.CQRS.Commands
{
	public class BookSlotCommandHandler : ICommandHandler<BookSlotCommand>
	{
		private readonly DeciderManager _manager;

		public BookSlotCommandHandler(DeciderManager manager)
		{
			_manager = manager;
		}

		public Task Handle(BookSlotCommand command)
		{
			var result = _manager.BookSlot(command.PatientId);
			return Task.CompletedTask;
		}
	}
}