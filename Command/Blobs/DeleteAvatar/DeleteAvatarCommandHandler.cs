using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;

namespace Command.Blobs.DeleteAvatar
{
    public class DeleteAvatarCommandHandler : IRequestHandler<DeleteAvatarCommand, string>
    {
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<User> _userRepository;
        public DeleteAvatarCommandHandler(IClassRepository<Image> imageRepository, IUserRepository<User> userRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(DeleteAvatarCommand command, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                UserId = command.UserId,
                ImageTitle = "https://thumbs.dreamstime.com/b/default-avatar-profile-trendy-style-social-media-user-icon-187599373.jpg",
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = "User"
            };
            _imageRepository.Add(image);
            _imageRepository.Save();

            return await Task.FromResult("1");
        }
    }
}
