using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Auth.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IClassRepository<Student> _studentsManager;
        private readonly IClassRepository<Teacher> _teachersManager;
        private readonly IClassRepository<Grade> _gradesManager;
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersManager;
        private readonly IClassRepository<AbsentList> _absentManager;
        public RegistrationCommandHandler(
            UserManager<User> userManager,
            IClassRepository<Student> studentsManager,
            IClassRepository<Teacher> teachersManager,
            IClassRepository<ClassTeacher> classesAndTeachersManager,
            IClassRepository<Grade> gradesManager,
            IClassRepository<AbsentList> absentManager)
        {
            _userManager = userManager;
            _studentsManager = studentsManager;
            _teachersManager = teachersManager;
            _classesAndTeachersManager = classesAndTeachersManager;
            _gradesManager = gradesManager;
            _absentManager = absentManager;
        }
        public async Task<int> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            bool isAdmin = false;
            int? isTeacher = null;
            int? isStudent = null;
            

            if (command.Type == 0)
            {
                Student student = new Student
                {
                    ClassId = (int)command.ClassId
                };
                _studentsManager.Add(student);
                _studentsManager.Save();
                var stud = student.Id;
                

                isAdmin = false;
                isTeacher = null;
                isStudent = stud;
            } else if (command.Type == 1)
            {
                Teacher teacher = new Teacher
                {
                    Position = command.Position,
                    Description = command.Description,
                    Experience = command.Experience
                };
                _teachersManager.Add(teacher);
                _teachersManager.Save();

                var teach = teacher.Id;

                ClassTeacher ct = new ClassTeacher
                {
                    ClassId = (int)command.ClassId,
                    SubjectId = (int)command.SubjectId,
                    TeacherId = teach
                };

                _classesAndTeachersManager.Add(ct);
                _classesAndTeachersManager.Save();

                var studsIds = _studentsManager.GetAll().Where(stud => stud.ClassId == (int)command.ClassId).Select(stud => stud.Id);

                //Grade emptyGrade = new Grade();
                var gradeList = new List<Grade>();
                var absList = new List<AbsentList>();

                foreach (var studId in studsIds)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Grade emptyGrade = new Grade
                        {
                            TeacherId = teach,
                            SubjectId = (int)command.SubjectId,
                            StudentId = studId,
                            StudentGrade = 0
                        };
                        gradeList.Add(emptyGrade);
                    }
                    AbsentList al = new AbsentList
                    {
                        SubjectId = (int)command.SubjectId,
                        StudentId = studId,
                        Labs = 0,
                        Seminars = 0,
                        Courses = 0
                    };
                    absList.Add(al);
                }
                _gradesManager.AddRange(gradeList);
                _gradesManager.Save();

                _absentManager.AddRange(absList);
                _absentManager.Save();

                

                isAdmin = false;
                isTeacher = teach;
                isStudent = null;
            } else
            {
                isAdmin = true;
                isTeacher = null;
                isStudent = null;
            }


            User user = new User
            {
                IsAdmin = isAdmin,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                Gender = command.Gender,
                DateOfBirth = command.DateOfBirth,
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = command.Email,
                UserName = command.Email,
                TeacherId = isTeacher,
                StudentId = isStudent,
                Images = new List<Image>()
                {
                    new Image { ImageTitle = "https://thumbs.dreamstime.com/b/default-avatar-profile-trendy-style-social-media-user-icon-187599373.jpg", CreatedBy = "D", CreatedAt = DateTimeOffset.Now}
                }
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return await Task.FromResult(-1);
            }

            var resultId = user.Id;

            return await Task.FromResult(resultId);
        }
    }
}
