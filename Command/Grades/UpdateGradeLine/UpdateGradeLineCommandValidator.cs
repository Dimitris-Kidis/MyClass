using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Grades.UpdateGradeLine
{
    public class UpdateGradeLineCommandValidator : AbstractValidator<UpdateGradeLineCommand>
    {
        public UpdateGradeLineCommandValidator()
        {
            RuleFor(line => line.Id)
                .NotEmpty();

            RuleFor(line => line.GradeOne)
                .InclusiveBetween(0, 10);

            RuleFor(line => line.GradeTwo)
                .InclusiveBetween(0, 10);

            RuleFor(line => line.GradeThree)
                .InclusiveBetween(0, 10);

            RuleFor(line => line.GradeFour)
                .InclusiveBetween(0, 10);

            RuleFor(line => line.Labs)
                .InclusiveBetween(0, 15);

            RuleFor(line => line.Seminars)
                .InclusiveBetween(0, 15);

            RuleFor(line => line.Courses)
                .InclusiveBetween(0, 15);
        }
    }
}
