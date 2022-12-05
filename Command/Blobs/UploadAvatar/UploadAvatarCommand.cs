using MediatR;
using Microsoft.AspNetCore.Http;

namespace Command.Blobs.UploadAvatar
{
    public class UploadAvatarCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public IFormFile Files { get; set; }
    }
}
