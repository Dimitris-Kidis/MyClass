using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Students.ViewModels;
using Query.Students.GetAboutInfo;
using Query.Students.GetAllClassmates;
using Query.Subjects.GetSubjectList;

namespace MyClass.Controllers.Students
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public StudentsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
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

        [HttpGet("subjects-{id}")]
        public async Task<IActionResult> GetAllSubjectsWithTeachersByClassId(int id)
        {
            var result = await _mediator.Send(new GetSubjectListQuery { ClassId = id });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<SubjectsWithTeachersViewModel>));
        }

        [HttpGet("classmates-{id}")]
        public async Task<IActionResult> GetAllClassmatesByClassId(int id)
        {
            var result = await _mediator.Send(new GetAllClassmatesQuery { ClassId = id });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassmatesViewModel>));
        }
    }
}
