using AutoMapper;
using Command.Improvements.CreateNewImprovement;
using Command.Notes.CreateNewNote;
using Command.Notes.DeleteNoteById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Common.ViewModels;
using Query.Notes.GetAllNotes;
using Query.Schedules.GetScheduleInfo;
using Query.Users.GetUser;
using Query.Users.GetUser;

namespace MyClass.Controllers.Common
{

    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CommonController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("improvement")]
        public async Task<IActionResult> CreateNewNote([FromBody] CreateNewImprovementCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("There's no improvement note with such id");
            return Ok(result);
        }

        [HttpGet("all-notes-for-user/{userId}")]
        public async Task<IActionResult> GetAllNotesByUserId(int userId)
        {
            var result = await _mediator.Send(new GetAllNotesByUserIdQuery { Id = userId });
            if (result == null || result.Count() == 0)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<NotesViewModel>));
        }

        [HttpPost("note")]
        public async Task<IActionResult> CreateNewNote([FromBody] CreateNewNoteCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("There's no user with such id");
            return Ok(result);
        }

        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteNoteByNoteId(int noteId)
        {
            var result = await _mediator.Send(new DeleteNoteByIdCommand { Id = noteId });
            if (result == -1) return NotFound("There's no note with such id");
            return Ok(result);
        }

        [HttpGet("schedule/{scheduleId}")]
        public async Task<IActionResult> GetSchedule(int scheduleId)
        {
            var result = await _mediator.Send(new GetScheduleQuery { ScheduleId = scheduleId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<ScheduleViewModel>(result));
        }
    }
}
