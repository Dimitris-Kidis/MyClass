using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradeLine
{
    public class GetGradeLineQueryHandler : IRequestHandler<GetGradeLineQuery, GradeLineDto>
    {
        private readonly IClassRepository<Grade> _gradesRepository;
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IClassRepository<ClassTeacher> _classesTeachersRepository;
        private readonly IMapper _mapper;

        public GetGradeLineQueryHandler(
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

        public async Task<GradeLineDto> Handle(GetGradeLineQuery request, CancellationToken cancellationToken)
        {
            var grade = _gradesRepository.FindBy(gradeLine => gradeLine.Id == request.GradeId).FirstOrDefault();

            return _mapper.Map<GradeLineDto>(grade);
        }
    }
}
