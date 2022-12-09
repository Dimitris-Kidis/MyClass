using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Teachers.ViewModels;
using Query.Teachers.GetAboutInfo;
using Query.Teachers.GetAllStudentTeachersByStudentId;
using Query.Teachers.GetAllTeachersWithIds;
using Query.Teachers.GetClassesWithStudentsNumber;

namespace MyClass.Controllers.Teachers
{

    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TeachersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("student-{studentId}")]
        public async Task<IActionResult> GetAllTeachersByStudentId(int studentId)
        {
            var result = await _mediator.Send(new GetAllStudentTeachersByStudentIdQuery { Id = studentId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<AllTeachersForStudentViewModel>));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllTeachersWithIds()
        {
            var result = await _mediator.Send(new GetAllTeachersWithIdsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<TeacherViewModel>));
        }

        [HttpGet("about-info-{id}")]
        public async Task<IActionResult> GetAboutInfo(int id)
        {
            var result = await _mediator.Send(new GetAboutInfoByIdQuery { Id = id });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<AboutInfoViewModel>(result));
        }

        [HttpGet("short-classes-info-{userId}")]
        public async Task<IActionResult> GetClassesWithNumberOfStudentsAndNumberOfSchedules(int userId)
        {
            var result = await _mediator.Send(new GetClassesWithStudentNumberByIdQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassesWithStudentsNumberViewModel>));
        }
    }
}
