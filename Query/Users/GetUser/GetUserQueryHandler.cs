using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<ApplicationCore.Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(
            IClassRepository<Image> imageRepository,
            IUserRepository<ApplicationCore.Domain.Entities.User> userRepository,
            IMapper mapper)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.FindBy(user => user.Id == request.UserId).FirstOrDefault();

            var userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                IsAdmin = user.IsAdmin,
                TeacherId = user.TeacherId,
                StudentId = user.StudentId,
                Avatar = _imageRepository.FindBy(image => image.UserId == user.Id).LastOrDefault().ImageTitle
            };

            return _mapper.Map<UserDto>(userDto);
        }
    }
}
