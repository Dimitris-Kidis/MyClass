using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Query.Teachers.GetAllStudentTeachersByStudentId
{
    public class GetAllStudentTeachersByStudentIdQueryHandler : IRequestHandler<GetAllStudentTeachersByStudentIdQuery, IEnumerable<TeacherListDto>>
    {
        private readonly IClassRepository<Student> _studRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectRepository;
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAllStudentTeachersByStudentIdQueryHandler(
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

        public async Task<IEnumerable<TeacherListDto>> Handle(GetAllStudentTeachersByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var students = _studRepository.FindBy(x => x.Id == request.Id).FirstOrDefault().ClassId;
            var classesAndTeachers = _classTeacherRepository.GetAll();
            var teachers = _teacherRepository.GetAll();
            var users = _userTeacherRepository.GetAll();
            var subjects = _subjectRepository.GetAll();
            var images = _imageRepository.GetAll();

            var teachersInfoByStidentId = 
                (from teacher in teachers
                join classTeacher in classesAndTeachers on teacher.Id equals classTeacher.TeacherId
                join user in users on teacher.Id equals user.TeacherId
                join subject in subjects on classTeacher.SubjectId equals subject.Id
                join image in images on user.Id equals image.UserId

                select new TeacherListDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Position = teacher.Position,
                    Description = teacher.Description,
                    Subject = subject.Name,
                    Avatar = image.ImageTitle
                }).ToList();

            return teachersInfoByStidentId.Select(_mapper.Map<TeacherListDto>);
        }
    }
}
