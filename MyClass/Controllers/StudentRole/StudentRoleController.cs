using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MyClass.Controllers.Common.ViewModels;
//using MyClass.Controllers.Student.ViewModels;
using MyClass.Controllers.StudentRole.ViewModels;
using Query.Grades.GetGradesWithAbsents;
using Query.Prints.DownloadStudentInfo;
using Query.Schedules.GetSchedulesForStudents;
using Query.Students.GetAboutInfo;
using Query.Students.GetAllClassmates;
using Query.Subjects.GetSubjectList;
using Query.Teachers.GetAllStudentTeachersByStudentId;
using Query.Teachers.GetAllTeachersWithIds;

namespace MyClass.Controllers.StudentRole
{
    [Route("api/student-controller")]
    [ApiController]
    public class StudentRoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public StudentRoleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
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

        [HttpGet("subjects-for-class/{classId}")]
        public async Task<IActionResult> GetAllSubjectsWithTeachersByClassId(int classId)
        {
            var result = await _mediator.Send(new GetSubjectListQuery { ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<SubjectsWithTeachersViewModel>));
        }

        [HttpGet("classmates/{classId}")]
        public async Task<IActionResult> GetAllClassmatesByClassId(int classId)
        {
            var result = await _mediator.Send(new GetAllClassmatesQuery { ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassmatesViewModel>));
        }

        [HttpGet("grades-for-student/{studentId}")]
        public async Task<IActionResult> GetGradesWithAbsentsByStudentId(int studentId)
        {
            var result = await _mediator.Send(new GetGradesWithAbsentsQuery { StudentId = studentId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<GradesWithAbsentsViewModel>));
        }

        [HttpGet("print-student-info/{userId}")]
        public async Task<IActionResult> GetStudentPrintInfoByUserId(int userId)

        {
            var result = await _mediator.Send(new DownloadStudentInfoQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            string fileName = "PersonalInfo.pdf";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string type);
            return File(result, type, fileName);
        }

        [HttpGet("schedule-for-class/{classId}")]
        public async Task<IActionResult> GetAllSchedulesByClassIdForStudents(int classId)
        {
            var result = await _mediator.Send(new GetSchedulesByClassIdQuery { ClassId = classId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<MyClass.Controllers.StudentRole.ViewModels.ScheduleViewModel>));
        }

        [HttpGet("teachers-of-student/{studentId}")]
        public async Task<IActionResult> GetAllTeachersByStudentId(int studentId)
        {
            var result = await _mediator.Send(new GetAllStudentTeachersByStudentIdQuery { Id = studentId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<AllTeachersForStudentViewModel>));
        }

    }
}
