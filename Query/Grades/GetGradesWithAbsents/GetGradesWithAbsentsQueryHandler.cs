using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradesWithAbsents
{
    public class GetGradesWithAbsentsQueryHandler : IRequestHandler<GetGradesWithAbsentsQuery, IEnumerable<GradesWithAbsentsDto>>
    {
        private readonly IClassRepository<Grade> _gradesRepository;
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IClassRepository<ClassTeacher> _classesTeachersRepository;
        private readonly IMapper _mapper;

        public GetGradesWithAbsentsQueryHandler(
            IClassRepository<Grade> gradesRepository,
            IClassRepository<Subject> subjectsRepository,
            IClassRepository<ClassTeacher> classesTeachersRepository,
            IMapper mapper)
        {
            _classesTeachersRepository = classesTeachersRepository;
            _subjectsRepository = subjectsRepository;
            _gradesRepository = gradesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GradesWithAbsentsDto>> Handle(GetGradesWithAbsentsQuery request, CancellationToken cancellationToken)
        {
            var grades = _gradesRepository.GetAll();
            var subjects = _subjectsRepository.GetAll();

            var gradesStud =
                (from subject in subjects
                 join grade in grades on subject.Id equals grade.SubjectId
                 where grade.StudentId == request.StudentId
                 select new GradesWithAbsentsDto
                 {
                     Subject = subject.Name,
                     GradeOne = grade.GradeOne,
                     GradeTwo = grade.GradeTwo,
                     GradeThree = grade.GradeThree,
                     GradeFour = grade.GradeFour,
                     Courses = grade.Courses,
                     Labs = grade.Labs,
                     Seminars = grade.Seminars,
                 }).ToListAsync(cancellationToken);

            return gradesStud.Result.Select(_mapper.Map<GradesWithAbsentsDto>);
        }
    }
}
