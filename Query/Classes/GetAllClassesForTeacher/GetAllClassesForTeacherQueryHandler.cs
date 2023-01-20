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

namespace Query.Classes.GetAllClassesForTeacher
{
    public class GetAllClassesForTeacherQueryHandler : IRequestHandler<GetAllClassesForTeacherQuery, IEnumerable<ClassForTeacherDto>>
    {
        private readonly IClassRepository<Class> _classesRepository;
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersRepository;
        private readonly IUserRepository<ApplicationCore.Domain.Entities.User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAllClassesForTeacherQueryHandler(
            IClassRepository<Class> classesRepository,
            IUserRepository<ApplicationCore.Domain.Entities.User> userTeacherRepository,
            IClassRepository<ClassTeacher> classesAndTeachersRepository,
            IMapper mapper)
        {
            _classesRepository = classesRepository;
            _userTeacherRepository = userTeacherRepository;
            _classesAndTeachersRepository = classesAndTeachersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassForTeacherDto>> Handle(GetAllClassesForTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacherId = _userTeacherRepository.FindBy(user => user.Id == request.UserId).FirstOrDefault().TeacherId;

            var allClassesWithTeachers = _classesAndTeachersRepository.GetAll();
            var allClasses = _classesRepository.GetAll();

            var classPairs = (from ac in allClasses
                              join ct in allClassesWithTeachers on ac.Id equals ct.ClassId
                              where ct.TeacherId == teacherId
                              select new ClassForTeacherDto
                                {
                                    Id = ac.Id,
                                    ClassName = ac.ClassName
                                }
                              ).ToListAsync(cancellationToken).Result.DistinctBy(x => x.Id);

            return classPairs.Select(_mapper.Map<ClassForTeacherDto>);
        }
    }
}
