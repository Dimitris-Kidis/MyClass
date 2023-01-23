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

namespace Query.Relations.GetAllRelations
{
    public class GetAllRelationsQueryHandler : IRequestHandler<GetAllRelationsQuery, IEnumerable<RelationDto>>
    {
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectRepository;
        private readonly IUserRepository<User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAllRelationsQueryHandler(
            IClassRepository<Class> classRepository,
            IClassRepository<ClassTeacher> classTeacherRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Subject> subjectRepository,
            IUserRepository<User> userTeacherRepository,
            IMapper mapper)
        {
            _classRepository = classRepository;
            _classTeacherRepository = classTeacherRepository;
            _teacherRepository = teacherRepository;
            _userTeacherRepository = userTeacherRepository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RelationDto>> Handle(GetAllRelationsQuery request, CancellationToken cancellationToken)
        {
            var classes = _classRepository.GetAll();
            var classesAndTeachers = _classTeacherRepository.GetAll();
            var subjects = _subjectRepository.GetAll();
            var users = _userTeacherRepository.GetAll();

            var classmates =
                 (from ct in classesAndTeachers
                  join user in users on ct.TeacherId equals user.TeacherId
                  join subject in subjects on ct.SubjectId equals subject.Id
                  join cl in classes on ct.ClassId equals cl.Id
                  select new RelationDto
                  {
                      SubjectName = subject.Name,
                      ClassName = cl.ClassName,
                      TeacherName = user.FirstName + " " + user.LastName
                  }).ToList();

            return classmates.Select(_mapper.Map<RelationDto>);
        }
    }
}
