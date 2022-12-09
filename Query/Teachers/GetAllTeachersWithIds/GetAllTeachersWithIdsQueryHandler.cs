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

namespace Query.Teachers.GetAllTeachersWithIds
{
    public class GetAllTeachersWithIdsQueryHandler : IRequestHandler<GetAllTeachersWithIdsQuery, IEnumerable<TeacherDto>>
    {
        private readonly IClassRepository<Teacher> _teachersRepository;
        private readonly IUserRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public GetAllTeachersWithIdsQueryHandler(
            IClassRepository<Teacher> teachersRepository,
            IUserRepository<User> usersRepository,
            IMapper mapper)
        {
            _teachersRepository = teachersRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> Handle(GetAllTeachersWithIdsQuery request, CancellationToken cancellationToken)
        {
            var users = _usersRepository.GetAll();
            var teachers = _teachersRepository.GetAll();

            var teacherWithId =
                (from user in users
                 join teacher in teachers on user.TeacherId equals teacher.Id
                 select new TeacherDto
                 {
                     Id = teacher.Id,
                     TeacherName = user.FirstName + " " + user.LastName,
                 }).ToList();

            return teacherWithId.Select(_mapper.Map<TeacherDto>);
        }
    }
}
