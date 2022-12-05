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

namespace Query.Subjects.GetSubjectList
{
    public class GetSubjectListQueryHandler : IRequestHandler<GetSubjectListQuery, IEnumerable<SubjectDto>>
    {
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersRepository;
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetSubjectListQueryHandler(
            IClassRepository<ClassTeacher> classesAndTeachersRepository,
            IClassRepository<Subject> subjectsRepository,
            IClassRepository<Teacher> teacherRepository,
            IUserRepository<User> userRepository,
            IMapper mapper)
        {
            _classesAndTeachersRepository = classesAndTeachersRepository;
            _subjectsRepository = subjectsRepository;
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            var pairs = _classesAndTeachersRepository
                .GetAll()
                .Where(pairs => pairs.ClassId == request.ClassId)
                .Select(list => new { TeacherId = list.TeacherId, SubjectId = list.SubjectId});

            var subjects = _subjectsRepository.GetAll();
            var users = _userRepository.GetAll().Where(user => user.TeacherId != null);

            var subjectsWithTeachers =
                (from pair in pairs
                 join user in users on pair.TeacherId equals user.TeacherId
                 join subject in subjects on pair.SubjectId equals subject.Id
                 select new SubjectDto
                 {
                     TeacherName = user.FirstName + user.LastName,
                     SubjectName = subject.Name
                 }).ToList();

            return subjectsWithTeachers.Select(_mapper.Map<SubjectDto>);
        }
    }
}
