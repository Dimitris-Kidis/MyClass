﻿using AutoMapper;
using Command.Classes.CreateClass;
using Command.ClassesAndTeachers.CreateNewClassTeacherRelationship;
using Command.Schedules.CreateSchedule;
using Command.Students.DeleteStudent;
using Command.Students.UpdateStudent;
using Command.Subjects.CreateSubject;
using Command.Teachers.DeleteTeacher;
using Command.Teachers.UpdateTeacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.AdminRole.ViewModels;
using Query.Admins;
using Query.Admins.GetAdminAboutInfo;
using Query.Admins.GetAdminsPaged;
using Query.Classes.GetAllClassesForTeacher;
using Query.Classes.GetAllClassesWithIds;
using Query.Classes.GetClassesAndSubjectsForTeacher;
using Query.Improvements.GetAllImprovements;
using Query.Relations.GetAllRelations;
using Query.Schedules.GetAllSchedules;
using Query.Students.GetStudent;
using Query.Students.GetStudentsPaged;
using Query.Subjects.GetAllSubjectsWithIds;
using Query.Teachers.GetAllTeachersWithIds;
using Query.Teachers.GetTeacher;
using Query.Teachers.GetTeachersPaged;

namespace MyClass.Controllers.AdminRole
{

    [Route("api/admin-controller")]
    [ApiController]
    public class AdminRoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AdminRoleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpDelete("student/{userId}")]
        public async Task<IActionResult> DeleteStudentById(int userId)
        {
            var result = await _mediator.Send(new DeleteStudentCommand { UserId = userId });
            if (result == -1) return NotFound("There's no student with such id");
            return Ok(result);
        }

        [HttpPut("student")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return NotFound("There's no student with such id");
            return NoContent();
        }

        [HttpGet("all-classes-with-ids")]
        public async Task<IActionResult> GetAllClassesWithIds()
        {
            var result = await _mediator.Send(new GetAllClassesWithIdsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassViewModel>));
        }

        [HttpPost("class")]
        public async Task<IActionResult> CreateNewClass([FromBody] CreateClassCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("class-teacher-subject-relation")]
        public async Task<IActionResult> CreateNewClassAndTeacherRelation([FromBody] CreateNewClassTeacherRelationshipCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("all-improvements")]
        public async Task<IActionResult> GetAllImprovements()
        {
            var result = await _mediator.Send(new GetAllImprovementsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ImprovementViewModel>));
        }

        [HttpGet("all-subjects-with-ids")]
        public async Task<IActionResult> GetAllSubjectsWithIds()
        {
            var result = await _mediator.Send(new GetAllSubjectsWithIdsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<SubjectViewModel>));
        }

        [HttpPost("subject")]
        public async Task<IActionResult> CreateNewSubject([FromBody] CreateSubjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("teacher/{userId}")]
        public async Task<IActionResult> DeleteTeacherByUserId(int userId)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand { UserId = userId });
            if (result == -1) return NotFound("There's no teacher with such id");
            return Ok(result);
        }

        [HttpPut("teacher")]
        public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return NotFound("There's no teacher with such id");
            return NoContent();
        }

        [HttpGet("teacher-classes-with-ids/{userId}")]
        public async Task<IActionResult> GetAllClassesForASpecificTeacher(int userId)
        {
            var result = await _mediator.Send(new GetAllClassesForTeacherQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClassForTeacherViewModel>));
        }

        [HttpGet("all-teachers-with-ids")]
        public async Task<IActionResult> GetAllTeachersWithIds()
        {
            var result = await _mediator.Send(new GetAllTeachersWithIdsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<TeacherViewModel>));
        }

        [HttpPost("students-paged")]
        public async Task<IActionResult> GetPagedStudents(GetPagedStudentsQuery query)
        {
            var pagedReviewsDto = await _mediator.Send(query);
            return Ok(pagedReviewsDto);
        }

        [HttpPost("teachers-paged")]
        public async Task<IActionResult> GetPagedTeachers(GetPagedTeachersQuery query)
        {
            var pagedReviewsDto = await _mediator.Send(query);
            return Ok(pagedReviewsDto);
        }

        [HttpGet("about-info/{userId}")]
        public async Task<IActionResult> GetAboutInfo(int userId)
        {
            var result = await _mediator.Send(new GetAdminAboutInfoQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<AdminAboutInfoViewModel>(result));
        }

        [HttpGet("student-or-admin/{userId}")]
        public async Task<IActionResult> GetStudentOrAdmin(int userId)
        {
            var result = await _mediator.Send(new GetStudentOrAdminQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<StudentOrAdminRowViewModel>(result));
        }

        [HttpGet("teacher/{userId}")]
        public async Task<IActionResult> GetTeacher(int userId)
        {
            var result = await _mediator.Send(new GetTeacherRowQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<TeacherRowViewModel>(result));
        }

        [HttpPost("admins-paged")]
        public async Task<IActionResult> GetPagedGrades(GetAdminsPagedQuery query)
        {
            var pagedGradesDto = await _mediator.Send(query);
            return Ok(pagedGradesDto);
        }

        [HttpGet("relations")]
        public async Task<IActionResult> GetAllRelations ()
        {
            var result = await _mediator.Send(new GetAllRelationsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<RelationViewModel>));
        }

        [HttpGet("all-schedules")]
        public async Task<IActionResult> GetAllSchedules()
        {
            var result = await _mediator.Send(new GetAllSchedulesQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<AllSchedulesViewModel>));
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> CreateNewSchedule([FromBody] CreateScheduleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}