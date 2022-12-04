using AutoMapper;
using Command.Notes.CreateNewNote;
using Command.Notes.DeleteNoteById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Notes.ViewModels;
using Query.Notes.GetAllNotes;

namespace MyClass.Controllers.Notes
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public NotesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllNotesByUserId(int id)
        {
            var result = await _mediator.Send(new GetAllNotesByUserIdQuery { Id = id });
            if (result == null || result.Count() == 0)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<NotesViewModel>));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewNote([FromBody] CreateNewNoteCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("There's no user with such id");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteById(int id)
        {
            var result = await _mediator.Send(new DeleteNoteByIdCommand { Id = id });
            if (result == -1) return NotFound("There's no note with such id");
            return Ok(result);
        }
    }
}
