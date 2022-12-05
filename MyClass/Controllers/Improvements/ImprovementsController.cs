﻿using AutoMapper;
using Command.Improvements.CreateNewImprovement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyClass.Controllers.Improvements
{
    [Route("api/improvements")]
    [ApiController]
    public class ImprovementsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ImprovementsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewNote([FromBody] CreateNewImprovementCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("There's no user with such id");
            return Ok(result);
        }
    }
}
