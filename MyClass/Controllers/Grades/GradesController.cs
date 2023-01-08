using AutoMapper;
using Command.Grades.UpdateGradeLine;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Query.Grades.GetGradesPaged;

namespace MyClass.Controllers.Grades
{
    [Route("api/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GradesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGradeLineByItsId([FromBody] UpdateGradeLineCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return NotFound("There's no grade line with such id");
            return NoContent();
        }

        [HttpPost("paginated")]
        public async Task<IActionResult> GetPagedGrades(GetPagedGradesForClassIdAndSubjectIdQuery query)
        {
            var pagedGradesDto = await _mediator.Send(query);
            return Ok(pagedGradesDto);
        }

    }
}
