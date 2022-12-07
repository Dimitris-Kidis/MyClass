using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Query.Prints.DownloadPersonalInfo;

namespace MyClass.Controllers.Prints
{
    [Route("api/print")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public PrintController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPrintInfoByUserId(int userId)
        
        {
            var result = await _mediator.Send(new DownloadPersonalInfoQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            string fileName = "PersonalInfo.pdf";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string type);
            return File(result, type, fileName);
        }
    }
}
