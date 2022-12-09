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

namespace Query.Teachers.GetAboutInfo
{
    public class GetAboutInfoByIdQueryHandler : IRequestHandler<GetAboutInfoByIdQuery, AboutInfoDto>
    {
        private readonly IClassRepository<Student> _studRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectRepository;
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAboutInfoByIdQueryHandler(
            IClassRepository<Student> studRepository,
            IClassRepository<Class> classRepository,
            IClassRepository<ClassTeacher> classTeacherRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Subject> subjectRepository,
            IUserRepository<User> userTeacherRepository,
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
            
            var fullName = user.FirstName + " " + user.LastName;
            var dateOfBirth = user.DateOfBirth.ToString("d", new CultureInfo("es-ES"));

            var numberOfSubjects = _classTeacherRepository.GetAll().Where(classes => classes.TeacherId == user.TeacherId).Count();
            var numberOfClasses = _classTeacherRepository.GetAll().Where(classes => classes.TeacherId == user.TeacherId).ToList().DistinctBy(dis => dis.ClassId).Count();

            var aboutInfo = new AboutInfoDto
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                NumberOfSubjects = numberOfSubjects,
                NumberOfClasses = numberOfClasses
            };

            return _mapper.Map<AboutInfoDto>(aboutInfo);
        }
    }
}
