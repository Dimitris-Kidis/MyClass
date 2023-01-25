using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.ClassesAndTeachers.DeleteClassTeacherRelationship
{
    public class DeleteClassTeacherRelationshipCommandHandler : IRequestHandler<DeleteClassTeacherRelationshipCommand, int>
    {
        private readonly IClassRepository<Grade> _gradeRepository;
        private readonly IClassRepository<Student> _studentRepository;
        private readonly IClassRepository<ClassTeacher> _classAndTeacherRepository;
        public DeleteClassTeacherRelationshipCommandHandler(
            IClassRepository<Grade> gradeRepository,
            IClassRepository<Student> studentRepository,
            IClassRepository<ClassTeacher> classAndTeacherRepository
            )
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _classAndTeacherRepository = classAndTeacherRepository;
        }
        public Task<int> Handle(DeleteClassTeacherRelationshipCommand request, CancellationToken cancellationToken)
        {
            var classTeacherSubjectRelation = _classAndTeacherRepository.FindBy(cts => cts.Id == request.ClassTeacherId).FirstOrDefault();

            var classId = classTeacherSubjectRelation.ClassId;
            var subjectId = classTeacherSubjectRelation.SubjectId;
            var teacherId = classTeacherSubjectRelation.TeacherId;

            var grades = _gradeRepository.FindBy(grade => grade.TeacherId == teacherId && grade.SubjectId == subjectId).ToList();

            var studs = _studentRepository.FindBy(stud => stud.ClassId == classId).Select(s => s.Id).ToList();


            var deleted = grades.Where(us => studs.Contains((int)us.StudentId)).ToList();

            //var gradesToDelete =
            //    (from grade in grades
            //     join stud in studs on grade.StudentId equals stud.Id
            //     select new Grade { }
            //     ).ToList<Grade>();

            _gradeRepository.DeleteRange(deleted);
            _gradeRepository.Save();

            if (classTeacherSubjectRelation != null)
            {
                _classAndTeacherRepository.Delete(classTeacherSubjectRelation);
                _classAndTeacherRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}
