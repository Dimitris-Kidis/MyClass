using AutoMapper;
using Command.Classes.CreateClass;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Classes.ViewModels;
using Query.Classes.GetAllClassesWithIds;
using Query.Classes.GetClassesAndSubjectsForTeacher;

namespace MyClass.Controllers.Classes
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ClassesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllClassesWithIds()
        {
            var result = await _mediator.Send(new GetAllClassesWithIdsQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            //return Ok(result.Select()_mapper.Map<ClassViewModel>(result));
            return Ok(result.Select(_mapper.Map<ClassViewModel>));
        }


        [HttpGet("classes-and-subjects-{userId}")]
        public async Task<IActionResult> GetAllClassesForTeacher(int userId)
        {
            var result = await _mediator.Send(new GetClassesAndSubjectsForTeacherQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            //return Ok(result.Select()_mapper.Map<ClassViewModel>(result));
            return Ok(result.Select(_mapper.Map<ClassAndSubjectViewModel>));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClass([FromBody] CreateClassCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}