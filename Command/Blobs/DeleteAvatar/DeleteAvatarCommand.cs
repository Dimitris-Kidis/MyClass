using MediatR;

namespace Command.Blobs.DeleteAvatar
{
    public class DeleteAvatarCommand : IRequest<string>
    {
        public int UserId { get; set; }
    }
}
