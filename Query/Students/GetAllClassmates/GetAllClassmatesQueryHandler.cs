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

namespace Query.Students.GetAllClassmates
{
    public class GetAllClassmatesQueryHandler : IRequestHandler<GetAllClassmatesQuery, IEnumerable<ClassmatesDto>>
    {
        private readonly IClassRepository<Student> _studRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectRepository;
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAllClassmatesQueryHandler(
            IClassRepository<Student> studRepository,
            IClassRepository<Class> classRepository,
            IClassRepository<ClassTeacher> classTeacherRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Subject> subjectRepository,
            IClassRepository<Image> imageRepository,
            IUserRepository<User> userTeacherRepository,
            IMapper mapper)
        {
            _studRepository = studRepository;
            _classRepository = classRepository;
            _classTeacherRepository = classTeacherRepository;
            _teacherRepository = teacherRepository;
            _userTeacherRepository = userTeacherRepository;
            _subjectRepository = subjectRepository;
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassmatesDto>> Handle(GetAllClassmatesQuery request, CancellationToken cancellationToken)
        {
            var students = _studRepository.FindBy(x => x.ClassId == request.ClassId).ToList();
            var users = _userTeacherRepository.GetAll();

            var info = new CultureInfo("es-ES");

            var classmates = 
                 (from student in students
                 join user in users on student.Id equals user.StudentId
                 select new ClassmatesDto
                 {
                     FullName = user.FirstName + " " + user.LastName,
                     Gender = user.Gender,
                     Email = user.Email,
                     DateOfBirth = user.DateOfBirth.ToString("d", info)
                 }).ToList();

            return classmates.Select(_mapper.Map<ClassmatesDto>);
        }
    }
}
