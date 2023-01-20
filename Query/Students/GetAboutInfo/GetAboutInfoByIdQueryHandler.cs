using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetAboutInfo
{
    public class GetAboutInfoByIdQueryHandler : IRequestHandler<GetAboutInfoByIdQuery, AboutInfoDto>
    {
        private readonly IClassRepository<Student> _studRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectRepository;
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<ApplicationCore.Domain.Entities.User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAboutInfoByIdQueryHandler(
            IClassRepository<Student> studRepository,
            IClassRepository<Class> classRepository,
            IClassRepository<ClassTeacher> classTeacherRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Subject> subjectRepository,
            IUserRepository<ApplicationCore.Domain.Entities.User> userTeacherRepository,
            IMapper mapper)
        {
            _studRepository = studRepository;
            _classRepository = classRepository;
            _classTeacherRepository = classTeacherRepository;
            _teacherRepository = teacherRepository;
            _userTeacherRepository = userTeacherRepository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<AboutInfoDto> Handle(GetAboutInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userTeacherRepository.FindBy(user => user.Id == request.Id).FirstOrDefault();
            
            var classId = _studRepository.FindBy(stud => stud.Id == user.StudentId).FirstOrDefault().ClassId;

            var fullName = user.FirstName + " " + user.LastName;
            var dateOfBirth = user.DateOfBirth.ToString("d", new CultureInfo("es-ES"));
            var className = _classRepository.FindBy(classes => classes.Id == classId).FirstOrDefault().ClassName;
            var numberOfClassmates = _studRepository.GetAll().Where(stud => stud.ClassId == classId).Count();
            var numberOfSubjects = _classTeacherRepository.GetAll().Where(classes => classes.ClassId == classId).Count();
            var numberOfTeachers = _classTeacherRepository.GetAll().Where(classes => classes.ClassId == classId).ToList().DistinctBy(dis => dis.TeacherId).Count();

            var aboutInfo = new AboutInfoDto
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                ClassName = className,
                NumberOfClassMates = numberOfClassmates,
                NumberOfSubjects = numberOfSubjects,
                NumberOfTeachers = numberOfTeachers
            };

            return _mapper.Map<AboutInfoDto>(aboutInfo);
        }
    }
}
