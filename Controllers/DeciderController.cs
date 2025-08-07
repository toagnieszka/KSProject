using KSProject.Patterns.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;

namespace KSProject.Controllers
{
	public class DeciderController : ControllerBase
	{
		private readonly ICommandHandler<InitSlotCommand> _initHandler;
		private readonly ICommandHandler<BookSlotCommand> _bookHandler;
		private readonly ICommandHandler<CancelSlotCommand> _cancelHandler;

		public DeciderController(
			 ICommandHandler<InitSlotCommand> initHandler,
			 ICommandHandler<BookSlotCommand> bookHandler,
			 ICommandHandler<CancelSlotCommand> cancelHandler)
		{
			_initHandler = initHandler;
			_bookHandler = bookHandler;
			_cancelHandler = cancelHandler;
		}

		[HttpPost("init")]
		public async Task<ActionResult> InitSlot([FromBody] InitSlotCommand command)
		{
			await _initHandler.Handle(command);
			return Ok();
		}

		[HttpPost("book")]
		public async Task<IActionResult> BookSlot([FromBody] BookSlotCommand command)
		{
			await _bookHandler.Handle(command);
			return Ok();
		}

		[HttpPost("cancel")]
		public async Task<IActionResult> CancelSlot()
		{
			await _cancelHandler.Handle(new CancelSlotCommand());
			return Ok();
		}
	}
}
