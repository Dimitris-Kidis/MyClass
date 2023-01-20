using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Grades.UpdateGradeLine
{
    public class UpdateGradeLineCommandHandler : IRequestHandler<UpdateGradeLineCommand, int>
    {
        private readonly IClassRepository<Grade> _gradesRepository;
        public UpdateGradeLineCommandHandler(IClassRepository<Grade> gradesRepository)
        {
            _gradesRepository = gradesRepository;
        }
        public Task<int> Handle(UpdateGradeLineCommand request, CancellationToken cancellationToken)
        {
            var grade = _gradesRepository
                .FindBy(gradeLine => gradeLine.Id == request.Id)
                .FirstOrDefault();
            if (grade != null)
            {
                grade.GradeOne = request.GradeOne;
                grade.GradeTwo = request.GradeTwo;
                grade.GradeThree = request.GradeThree;
                grade.GradeFour = request.GradeFour;
                grade.Courses = request.Courses;
                grade.Labs = request.Labs;
                grade.Seminars = request.Seminars;
                _gradesRepository.Update(grade);
                _gradesRepository.Save();
            }
            else
            {
                return Task.FromResult(-1);
            }

            return Task.FromResult(0);
        }
    }
}
