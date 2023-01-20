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

namespace Query.Prints.DownloadTeacherInfo
{
    public class DownloadTeacherInfoQueryHandler : IRequestHandler<DownloadTeacherInfoQuery, Stream>
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
                        <span style='display: block; margin-bottom: 10px;'>Joined On: {{JoinedOn}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Number Of Classes: {{NumberOfClasses}}</span>
                        <span style='display: block; margin-bottom: 10px;'>Number Of Subjects: {{NumberOfSubjects}}</span>
                    </div>

                <h1>Class: {{ClassName}}</h1>
                
                <table style='margin-top: 40px; margin-bottom: 20px; border-collapse: collapse; width: 100%;' border='1px'>
                        <tr>
                            <th style='padding: 4px;'>Subject</th>
                            <th style='padding: 4px;'>Student</th>
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

        public DownloadTeacherInfoQueryHandler(
            IClassRepository<Student> studRepository,
            IClassRepository<Class> classRepository,
            IClassRepository<ClassTeacher> classTeacherRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Subject> subjectsRepository,
            IClassRepository<Grade> gradesRepository,
            IClassRepository<Image> imageRepository,
            IUserRepository<User> userTeacherRepository,
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

        public async Task<Stream> Handle(DownloadTeacherInfoQuery request, CancellationToken cancellationToken)
        {
            var grades = _gradesRepository.GetAll();
            var subjects = _subjectsRepository.GetAll();
            var teachers = _teacherRepository.GetAll();
            var users = _userTeacherRepository.GetAll();
            var students = _studRepository.GetAll();
            var classes = _classRepository.GetAll();
            var classesAndTeachers = _classTeacherRepository.GetAll();


            var user = _userTeacherRepository
                .FindBy(user => user.Id == request.UserId)
                .FirstOrDefault();
            var teacherId = user.TeacherId;
            var images = await _imageRepository
                .GetAll()
                .ToListAsync(cancellationToken);

            var fullName = user.FirstName + " " + user.LastName;
            var dateOfBirth = user.DateOfBirth.ToString("d", new CultureInfo("es-ES"));
            var actualDate = DateTime.Now.ToString("d", new CultureInfo("es-ES"));
            var joinedOn = user.CreatedAt.ToString("d", new CultureInfo("es-ES"));
            var avatarLink = images.Where(y => y.UserId == user.Id).Select(x => x.ImageTitle).LastOrDefault();

            var numberOfClasses = _classTeacherRepository.FindBy(classes => classes.TeacherId == user.TeacherId).DistinctBy(dis => dis.ClassId).Select(p => p.ClassId).Count();
            var numberOfSubjects = _classTeacherRepository.FindBy(classes => classes.TeacherId == user.TeacherId).DistinctBy(dis => dis.SubjectId).Select(p => p.SubjectId).Count();

            var className = _classRepository.FindBy(clas => clas.Id == request.ClassId).FirstOrDefault().ClassName;

            var newPerson = new TeacherInfoData
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                JoinedOn = joinedOn,
                AvatarLink = avatarLink,
                NumberOfClasses = numberOfClasses,
                NumberOfSubjects = numberOfSubjects,
                ActualDate = actualDate,
                ClassName = className
            };




            var tables = "";




            


            //var subjectsNumber = _classTeacherRepository.FindBy(ct => ct.TeacherId == teacherId && ct.ClassId == request.ClassId).Select(x => x.SubjectId).ToList();
            var subjectsNumber = _classTeacherRepository.FindBy(ct => ct.TeacherId == teacherId && ct.ClassId == request.ClassId).ToList();


            for (int i = 0; i < subjectsNumber.Count(); i++)
            {
                tables +=
                    @$"   
                    <tr>
                        <td style='text-align: center;'>{_subjectsRepository.FindBy(x => x.Id == subjectsNumber[i].SubjectId).FirstOrDefault().Name}</td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'></td>
                    </tr>
                    ";
                var gradess = _gradesRepository.FindBy(x => x.TeacherId == teacherId && x.SubjectId == subjectsNumber[i].SubjectId).ToList();
                var allInfo =
                    (from grade in gradess
                     join oneUser in users on grade.StudentId equals oneUser.StudentId
                     select new
                     {
                         StudentName = oneUser.FirstName + " " + oneUser.LastName,
                         GradeOne = grade.GradeOne,
                         GradeTwo = grade.GradeTwo,
                         GradeThree = grade.GradeThree,
                         GradeFour = grade.GradeFour,
                         Courses = grade.Courses,
                         Labs = grade.Labs,
                         Seminars = grade.Seminars,
                     }).OrderBy(x => x.StudentName).ToList();
                for (int j = 0; j < allInfo.Count(); j++)
                {
                    tables +=
                    @$"   
                    <tr>
                        <td style='text-align: center;'></td>
                        <td style='text-align: center;'>{allInfo[j].StudentName}</td>
                        <td style='text-align: center;'>{allInfo[j].GradeOne}</td>
                        <td style='text-align: center;'>{allInfo[j].GradeTwo}</td>
                        <td style='text-align: center;'>{allInfo[j].GradeThree}</td>
                        <td style='text-align: center;'>{allInfo[j].GradeFour}</td>
                        <td style='text-align: center;'>{allInfo[j].Courses}</td>
                        <td style='text-align: center;'>{allInfo[j].Labs}</td>
                        <td style='text-align: center;'>{allInfo[j].Seminars}</td>
                    </tr>
                    ";
                }
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
