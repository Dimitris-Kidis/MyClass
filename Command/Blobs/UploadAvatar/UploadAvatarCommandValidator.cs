using FluentValidation;

namespace Command.Blobs.UploadAvatar
{
    public class UploadAvatarCommandValidator : AbstractValidator<UploadAvatarCommand>
    {
        public UploadAvatarCommandValidator()
        {
            RuleFor(avatar => avatar.UserId)
                .NotEmpty();

            RuleFor(avatar => avatar.Files)
                .NotEmpty()
                .Must(a => a.ContentType == "image/png" || a.ContentType == "image/jpeg").WithMessage($"Avatar format should be either .png or .jpeg.");
        }
    }
}
