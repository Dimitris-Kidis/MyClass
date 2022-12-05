using AutoMapper;
using Command.Blobs.DeleteAvatar;
using Command.Blobs.UploadAvatar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyClass.Controllers.Avatars
{

    [Route("api/avatars")]
    [ApiController]
    public class AvatarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AvatarsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar([FromForm] UploadAvatarCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvatar(int id)
        {
            var result = await _mediator.Send(new DeleteAvatarCommand { UserId = id });
            if (result == "") return NotFound("There's no user with such id");
            return Ok(result);
        }
    }
}
