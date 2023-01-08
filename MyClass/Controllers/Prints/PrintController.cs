using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Query.Prints.DownloadStudentInfo;
using Query.Prints.DownloadTeacherInfo;

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

        [HttpGet("student/{userId}")]
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

        [HttpGet("teacher/{userId}/{classId}")]
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
    }
}
