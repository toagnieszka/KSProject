using KSProject.Decider;

namespace KSProject.Patterns.CQRS.Commands
{
	public class InitSlotCommandHandler : ICommandHandler<InitSlotCommand>
	{
		private readonly DeciderManager deciderManager;

		public InitSlotCommandHandler(DeciderManager deciderManager)
		{
			this.deciderManager = deciderManager;
		}

		public Task Handle(InitSlotCommand command)
		{
			deciderManager.InitSlot(command.AppointmentId, command.DoctorId, command.Start, command.End);
			return Task.CompletedTask; 
		}
	}
}
