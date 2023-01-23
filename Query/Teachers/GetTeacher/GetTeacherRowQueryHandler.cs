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

namespace Query.Teachers.GetTeacher
{
    public class GetTeacherRowQueryHandler : IRequestHandler<GetTeacherRowQuery, TeacherRowDto>
    {
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IUserRepository<ApplicationCore.Domain.Entities.User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetTeacherRowQueryHandler(
            IClassRepository<Teacher> teacherRepository,
            IUserRepository<ApplicationCore.Domain.Entities.User> userTeacherRepository,
            IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _userTeacherRepository = userTeacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherRowDto> Handle(GetTeacherRowQuery request, CancellationToken cancellationToken)
        {
            var user = _userTeacherRepository.FindBy(user => user.Id == request.UserId).FirstOrDefault();
            var teacher = _teacherRepository.FindBy(teacher => teacher.Id == user.TeacherId).FirstOrDefault();

            var aboutInfo = new TeacherRowDto
            {
                Id = request.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Description = teacher.Description,
                Experience = teacher.Experience,
                Position = teacher.Position,
            };

            return _mapper.Map<TeacherRowDto>(aboutInfo);
        }
    }
}


