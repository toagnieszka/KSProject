using KSProject.Decider;

namespace KSProject.Patterns.CQRS.Commands
{
	public class CancelSlotCommandHandler : ICommandHandler<CancelSlotCommand>
	{
		private readonly DeciderManager _manager;

		public CancelSlotCommandHandler(DeciderManager manager)
		{
			_manager = manager;
		}

		public Task Handle(CancelSlotCommand command)
		{
			var result = _manager.CancelSlot();
			return Task.CompletedTask;
		}
	}
}
