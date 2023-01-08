using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.ClassesAndTeachers.CreateNewClassTeacherRelationship
{
    public class CreateNewClassTeacherRelationshipCommandHandler : IRequestHandler<CreateNewClassTeacherRelationshipCommand, int>
    {
        private readonly IClassRepository<ClassTeacher> _classAndTeacherRepository;
        private readonly IClassRepository<Student> _studsRepository;
        private readonly IClassRepository<Grade> _gradesRepository;
        public CreateNewClassTeacherRelationshipCommandHandler(
            IClassRepository<ClassTeacher> classAndTeacherRepository,
            IClassRepository<Student> studsRepository,
            IClassRepository<Grade> gradesRepository)
        {
            _classAndTeacherRepository = classAndTeacherRepository;
            _studsRepository = studsRepository;
            _gradesRepository = gradesRepository;
        }
        public Task<int> Handle(CreateNewClassTeacherRelationshipCommand request, CancellationToken cancellationToken)
        {
            var newClassTeacherRelation = new ClassTeacher
            {
                ClassId = request.ClassId,
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId
            };

            _classAndTeacherRepository.Add(newClassTeacherRelation);
            _classAndTeacherRepository.Save();

            var resultId = newClassTeacherRelation.Id;




            var studsIds = _studsRepository.GetAll().Where(stud => stud.ClassId == request.ClassId).Select(stud => stud.Id);

            var gradeList = new List<Grade>();

            foreach (var studId in studsIds)
            {

                Grade emptyGrade = new Grade
                {
                    TeacherId = request.TeacherId,
                    SubjectId = request.SubjectId,
                    StudentId = studId,
                    GradeOne = 0,
                    GradeTwo = 0,
                    GradeThree = 0,
                    GradeFour = 0,
                    Labs = 0,
                    Seminars = 0,
                    Courses = 0
                };
                gradeList.Add(emptyGrade);

            }
            _gradesRepository.AddRange(gradeList);
            _gradesRepository.Save();

            return Task.FromResult(resultId);
        }
    }
}
