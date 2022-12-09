using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Schedules.ViewModels;
using Query.Schedules.GetSchedulesForStudents;
using Query.Schedules.GetSchedulesForTeachers;

namespace MyClass.Controllers.Schedules
{
    [Route("api/schedules")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public SchedulesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("students/{classId}")]
        public async Task<IActionResult> GetAllSchedulesByClassIdForStudents(int classId)
        {
            var result = await _mediator.Send(new GetSchedulesByClassIdQuery { ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ScheduleViewModel>));
        }

        [HttpGet("teachers/{userId}")]
        public async Task<IActionResult> GetAllSchedulesByUserIdForTeachers(int userId)
        {
            var result = await _mediator.Send(new GetSchedulesByUserIdQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ScheduleForTeachersViewModel>));
        }
    }
}
