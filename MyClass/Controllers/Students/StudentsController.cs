using AutoMapper;
using Command.Students.DeleteStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Students.ViewModels;
using Query.Grades.GetGradesWithAbsents;
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

        [HttpGet("about-info-{studentId}")]
        public async Task<IActionResult> GetAboutInfo(int studentId)
        {
            var result = await _mediator.Send(new GetAboutInfoByIdQuery { Id = studentId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<AboutInfoViewModel>(result));
        }

        [HttpGet("subjects-{classId}")]
        public async Task<IActionResult> GetAllSubjectsWithTeachersByClassId(int classId)
        {
            var result = await _mediator.Send(new GetSubjectListQuery { ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<SubjectsWithTeachersViewModel>));
        }

        [HttpGet("classmates-{classId}")]
        public async Task<IActionResult> GetAllClassmatesByClassId(int classId)
        {
            var result = await _mediator.Send(new GetAllClassmatesQuery { ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassmatesViewModel>));
        }

        [HttpGet("grades-{studentId}")]
        public async Task<IActionResult> GetGradesWithAbsentsByStudentId(int studentId)
        {
            var result = await _mediator.Send(new GetGradesWithAbsentsQuery { StudentId = studentId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<GradesWithAbsentsViewModel>));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteStudentById(int userId)
        {
            var result = await _mediator.Send(new DeleteStudentCommand { UserId = userId });
            if (result == -1) return NotFound("There's no student with such id");
            return Ok(result);
        }
    }
}
