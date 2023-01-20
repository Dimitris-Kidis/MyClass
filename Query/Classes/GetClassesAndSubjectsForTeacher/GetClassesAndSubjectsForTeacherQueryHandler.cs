using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetClassesAndSubjectsForTeacher
{
    public class GetClassesAndSubjectsForTeacherQueryHandler : IRequestHandler<GetClassesAndSubjectsForTeacherQuery, IEnumerable<ClassAndSubjectDto>>
    {
        private readonly IClassRepository<Class> _classesRepository;
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersRepository;
        private readonly IUserRepository<User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetClassesAndSubjectsForTeacherQueryHandler(
            IClassRepository<Subject> subjectsRepository,
            IClassRepository<Class> classesRepository,
            IUserRepository<User> userTeacherRepository,
            IClassRepository<ClassTeacher> classesAndTeachersRepository,
            IMapper mapper)
        {
            _subjectsRepository = subjectsRepository;
            _classesRepository = classesRepository;
            _userTeacherRepository = userTeacherRepository;
            _classesAndTeachersRepository = classesAndTeachersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassAndSubjectDto>> Handle(GetClassesAndSubjectsForTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacherId = _userTeacherRepository
                .FindBy(user => user.Id == request.UserId)
                .FirstOrDefault()
                .TeacherId;

            var allClassesWithTeachers = _classesAndTeachersRepository.GetAll();
            var allClasses = _classesRepository.GetAll();
            var allSubjects = _subjectsRepository.GetAll();

            var classesWithSubjectForTeacher = (from ct in allClassesWithTeachers
                              join c in allClasses on ct.ClassId equals c.Id
                              join s in allSubjects on ct.SubjectId equals s.Id
                              where ct.TeacherId == teacherId
                              select new ClassAndSubjectDto
                              {
                                  ClassId = ct.ClassId,
                                  ClassName = c.ClassName,
                                  SubjectId = s.Id,
                                  SubjectName = s.Name
                              }
                              ).ToListAsync(cancellationToken);

            return classesWithSubjectForTeacher.Result.Select(_mapper.Map<ClassAndSubjectDto>);
        }
    }
}
