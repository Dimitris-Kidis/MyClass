using AutoMapper;
using Command.ClassesAndTeachers.CreateNewClassTeacherRelationship;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyClass.Controllers.ClassesAndTeachers
{
    [Route("api/classes-and-teachers")]
    [ApiController]
    public class ClassesAndTeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ClassesAndTeachersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClassAndTeacherRelation([FromBody] CreateNewClassTeacherRelationshipCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }

}


