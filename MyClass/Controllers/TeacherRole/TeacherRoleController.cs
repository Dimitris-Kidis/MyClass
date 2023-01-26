using AutoMapper;
using Command.Grades.UpdateGradeLine;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MyClass.Controllers.TeacherRole.ViewModels;
using Query.Classes.GetClassesAndSubjectsForTeacher;
using Query.Grades.GetGradeLine;
using Query.Grades.GetGradesPaged;
using Query.Prints.DownloadTeacherInfo;
using Query.Schedules.GetSchedulesForTeachers;
using Query.Teachers.GetAboutInfo;
using Query.Teachers.GetClassesWithStudentsNumber;

namespace MyClass.Controllers.Teacher
{

    [Route("api/teacher-controller")]
    [ApiController]
    public class TeacherRoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TeacherRoleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("grades-paged")]
        public async Task<IActionResult> GetPagedGrades(GetPagedGradesForClassIdAndSubjectIdQuery query)
        {
            var pagedGradesDto = await _mediator.Send(query);
            return Ok(pagedGradesDto);
        }

        [HttpGet("print/{userId}/{classId}")]
        public async Task<IActionResult> GetTeacherPrintInfoByUserId(int userId, int classId)

        {
            var result = await _mediator.Send(new DownloadTeacherInfoQuery { UserId = userId, ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            string fileName = "PersonalInfo.pdf";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string type);
            return File(result, type, fileName);
        }

        [HttpGet("schedule/{userId}")]
        public async Task<IActionResult> GetAllSchedulesByUserIdForTeachers(int userId)
        {
            var result = await _mediator.Send(new GetSchedulesByUserIdQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ScheduleForTeachersViewModel>));
        }

        [HttpGet("about-info/{userId}")]
        public async Task<IActionResult> GetAboutInfo(int userId)
        {
            var result = await _mediator.Send(new GetAboutInfoByIdQuery { Id = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<AboutInfoViewModel>(result));
        }

        [HttpGet("short-classes-info/{userId}")]
        public async Task<IActionResult> GetClassesWithNumberOfStudentsAndNumberOfSchedules(int userId)
        {
            var result = await _mediator.Send(new GetClassesWithStudentNumberByIdQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassesWithStudentsNumberViewModel>));
        }

        [HttpGet("classes-and-subjects-with-their-ids-for-pagination/{userId}")]
        public async Task<IActionResult> GetAllClassesForTeacher(int userId)
        {
            var result = await _mediator.Send(new GetClassesAndSubjectsForTeacherQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassAndSubjectViewModel>));
        }

        [HttpGet("gradeline/{gradeId}")]
        public async Task<IActionResult> GetGradeLine(int gradeId)
        {
            var result = await _mediator.Send(new GetGradeLineQuery { GradeId = gradeId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<GradeLineViewModel>(result));
        }

        [HttpPut("grade-update")]
        public async Task<IActionResult> UpdateGradeLineByItsId([FromBody] UpdateGradeLineCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return NotFound("There's no grade line with such id");
            return NoContent();
        }
    }
}
