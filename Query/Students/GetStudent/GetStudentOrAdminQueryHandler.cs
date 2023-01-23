using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using Query.Students.GetStudent;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetStudent
{
    public class GetStudentOrAdminQueryHandler : IRequestHandler<GetStudentOrAdminQuery, StudentOrAdminRowDto>
    {
        private readonly IClassRepository<Student> _studRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectRepository;
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<ApplicationCore.Domain.Entities.User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetStudentOrAdminQueryHandler(
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

        public async Task<StudentOrAdminRowDto> Handle(GetStudentOrAdminQuery request, CancellationToken cancellationToken)
        {
            var user = _userTeacherRepository.FindBy(user => user.Id == request.UserId).FirstOrDefault();

            var aboutInfo = new StudentOrAdminRowDto
            {
                Id = request.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender
            };  

            return _mapper.Map<StudentOrAdminRowDto>(aboutInfo);
        }
    }
}
