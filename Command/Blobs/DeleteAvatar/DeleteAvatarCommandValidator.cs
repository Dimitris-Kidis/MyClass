using FluentValidation;

namespace Command.Blobs.DeleteAvatar
{
    public class DeleteAvatarCommandValidator : AbstractValidator<DeleteAvatarCommand>
    {
        public DeleteAvatarCommandValidator()
        {
            RuleFor(avatar => avatar.UserId)
                .NotEmpty();
        }
    }
}
