using MediatR;

namespace Command.Auth.ChangePassword
{
    public class ChangePasswordCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
