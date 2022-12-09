using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyClass.Controllers.Classes.ViewModels;
using Query.Classes.GetAllClassesWithIds;

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
    }
}