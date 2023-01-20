using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using HandlebarsDotNet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Query.Prints.DownloadStudentInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Query.Prints.DownloadStudentInfo
{
    public class DownloadStudentInfoQueryHandler : IRequestHandler<DownloadStudentInfoQuery, Stream>
    {
        private readonly IClassRepository<Student> _studRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<ClassTeacher> _classTeacherRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IClassRepository<Grade> _gradesRepository;
        private readonly IUserRepository<User> _userTeacherRepository;
        private readonly IMapper _mapper;

        private string _htmlTemplate = @"
        <html>
            <head>
                <style>
                    * {
                        box-sizing: border-box;
                    }   
                    .cont {
                        
                    }
                </style>
            </head>
            <body>
                <h1 style='font-size: 60px; text-align: center;'>Info</h1>
                    <div style='display: inline-block !important; text-align: center; width: 45%'>
                        <img src='{{AvatarLink}}' alt='' style='width: 200px;'>
                    </div>
                    <div style='display: inline-block !important; width: 45%; text-align: center;'>
                        <span style='display: block; margin-bottom: 10px;'><h1>{{FullName}}</h1></span>
                        <span style='display: block; margin-bottom: 10px;'>Birth Date: {{DateOfBirth}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Class: {{ClassName}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Joined On: {{JoinedOn}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Number Of Classmates: {{NumberOfClassmates}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Number Of Teachers: {{NumberOfTeachers}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Number Of Subjects: {{NumberOfSubjects}}</span>
                    </div>

              
                
                <table style='margin-top: 40px; margin-bottom: 20px; border-collapse: collapse; width: 100%;' border='1px'>
                        <tr>
                            <th style='padding: 4px;'>Subject</th>
                            <th style='padding: 4px;'>Att. I</th>
                            <th style='padding: 4px;'>Att. II</th>
                            <th style='padding: 4px;'>Ind. Work</th>
                            <th style='padding: 4px;'>Current</th>
                            <th style='padding: 4px;'>Course Abs.</th>
                            <th style='padding: 4px;'>Lab Abs.</th>
                            <th style='padding: 4px;'>Seminar Abs.</th>
                        </tr>
                        
               ";
        private string _middle =
            @"
                </table>
                <table style='margin-top: 40px; margin-bottom: 20px; border-collapse: collapse; width: 100%;' border='1px'>
                        <tr>
                            <th style='padding: 4px;'>Subject</th>
                            <th style='padding: 4px;'>Teacher</th>
                        </tr>
            ";
        private string _tail =
            @"
                </table>
                <div style='float: right;'>
                    <p><strong>Date:</strong> {{ActualDate}}</p> 
                </div>
            </body>
        </html>";

        public DownloadStudentInfoQueryHandler(
            IClassRepository<Student> studRepository,
            IClassRepository<Class> classRepository,
            IClassRepository<ClassTeacher> classTeacherRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Subject> subjectsRepository,
            IClassRepository<Grade> gradesRepository,
            IClassRepository<Image> imageRepository,
            IUserRepository<ApplicationCore.Domain.Entities.User> userTeacherRepository,
            IMapper mapper)
        {
            _studRepository = studRepository;
            _classRepository = classRepository;
            _classTeacherRepository = classTeacherRepository;
            _teacherRepository = teacherRepository;
            _imageRepository = imageRepository;
            _gradesRepository = gradesRepository;
            _userTeacherRepository = userTeacherRepository;
            _subjectsRepository = subjectsRepository;
            _mapper = mapper;
        }

        public async Task<Stream> Handle(DownloadStudentInfoQuery request, CancellationToken cancellationToken)
        {
            var user = _userTeacherRepository
                .FindBy(user => user.Id == request.UserId)
                .FirstOrDefault();
            var images = await _imageRepository
                .GetAll()
                .ToListAsync(cancellationToken);

            var classId = _studRepository
                .FindBy(stud => stud.Id == user.StudentId)
                .FirstOrDefault()
                .ClassId;

            var fullName = user.FirstName + " " + user.LastName;
            var dateOfBirth = user.DateOfBirth.ToString("d", new CultureInfo("es-ES"));
            var actualDate = DateTime.Now.ToString("d", new CultureInfo("es-ES"));
            var joinedOn = user.CreatedAt.ToString("d", new CultureInfo("es-ES"));
            var avatarLink = images.Where(y => y.UserId == user.Id).Select(x => x.ImageTitle).LastOrDefault();
            var className = _classRepository.FindBy(classes => classes.Id == classId).FirstOrDefault().ClassName;
            var numberOfClassmates = _studRepository.GetAll().Where(stud => stud.ClassId == classId).Count();
            var numberOfSubjects = _classTeacherRepository.GetAll().Where(classes => classes.ClassId == classId).Count();
            var numberOfTeachers = _classTeacherRepository.GetAll().Where(classes => classes.ClassId == classId).ToList().DistinctBy(dis => dis.TeacherId).Count();


            var grades = _gradesRepository.GetAll();
            var subjects = _subjectsRepository.GetAll();
            var teachers = _teacherRepository.GetAll();
            var users = _userTeacherRepository.GetAll();

            var gradesStud =
                (from subject in subjects
                 join grade in grades on subject.Id equals grade.SubjectId
                 where grade.StudentId == user.StudentId
                 select new
                 {
                     Subject = subject.Name,
                     grade.GradeOne,
                     grade.GradeTwo,
                     grade.GradeThree,
                     grade.GradeFour,
                     grade.Courses,
                     grade.Labs,
                     grade.Seminars,
                 }).ToListAsync(cancellationToken).Result;

            var newPerson = new StudentInfoData
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                ClassName = className,
                JoinedOn = joinedOn,
                AvatarLink = avatarLink,
                NumberOfClassmates = numberOfClassmates,
                NumberOfSubjects = numberOfSubjects,
                NumberOfTeachers = numberOfTeachers,
                ActualDate = actualDate
            };

            var teachersWithSubjects =
                (from subject in subjects
                 join grade in grades on subject.Id equals grade.SubjectId
                 join teacher in teachers on grade.TeacherId equals teacher.Id
                 join userr in users on teacher.Id equals userr.TeacherId
                 where grade.StudentId == user.StudentId
                 select new
                 {
                     Subject = subject.Name,
                     Teacher = userr.FirstName + " " + userr.LastName,
                 }).ToListAsync(cancellationToken).Result;


            var tables = "";
            for (int i = 0; i < gradesStud.Count(); i++)
            {
                tables +=
                    @$"
                    <tr>    
                        <td style='text-align: center;'>{gradesStud[i].Subject}</td>
                        <td style='text-align: center;'>{gradesStud[i].GradeOne}</td>
                        <td style='text-align: center;'>{gradesStud[i].GradeTwo}</td>
                        <td style='text-align: center;'>{gradesStud[i].GradeThree}</td>
                        <td style='text-align: center;'>{gradesStud[i].GradeFour}</td>
                        <td style='text-align: center;'>{gradesStud[i].Courses}</td>
                        <td style='text-align: center;'>{gradesStud[i].Labs}</td>
                        <td style='text-align: center;'>{gradesStud[i].Seminars}</td>
                    </tr>
                    ";
            }
            _htmlTemplate += tables;
            _htmlTemplate += _middle;
            tables = "";


            for (int i = 0; i < teachersWithSubjects.Count(); i++)
            {
                tables +=
                    @$"
                    <tr>    
                        <td style='text-align: center;'>{teachersWithSubjects[i].Subject}</td>
                        <td style='text-align: center;'>{teachersWithSubjects[i].Teacher}</td>
                    </tr>
                    ";
            }
            _htmlTemplate += tables;
            _htmlTemplate += _tail;

            var template = Handlebars.Compile(_htmlTemplate);
            var html = template(newPerson);
            var pdf = await GeneratePdfAsync(html);
            Stream stream = new MemoryStream(pdf);
            return stream;
        }

        private Task<byte[]> GeneratePdfAsync(string html)
        {
            var wkhtmltopdfPath = Path.Combine(Environment.CurrentDirectory, "Infrastructure/Rotativa");
            var result = WkhtmlDriver.Convert(wkhtmltopdfPath, new ConvertOptions().GetConvertOptions(), html);
            return Task.FromResult(result);
        }
    }
}
