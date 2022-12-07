using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Teachers.ViewModels;
using Query.Teachers.GetAllStudentTeachersByStudentId;

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
            //return Ok(_mapper.Map<AllTeachersForStudentViewModel>(result));
            return Ok(result.Select(_mapper.Map<AllTeachersForStudentViewModel>));
        }
    }
}
