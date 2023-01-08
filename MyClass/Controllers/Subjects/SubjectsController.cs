using AutoMapper;
using Command.Subjects.CreateSubject;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Subjects.ViewModels;
using Query.Subjects.GetAllSubjectsWithIds;

namespace MyClass.Controllers.Subjects
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public SubjectsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllClassesWithIds()
        {
            var result = await _mediator.Send(new GetAllSubjectsWithIdsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<SubjectViewModel>));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSubject([FromBody] CreateSubjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
