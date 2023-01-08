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
                .NotEmpty()
                .InclusiveBetween(1, 10);

            RuleFor(line => line.GradeTwo)
                .NotEmpty()
                .InclusiveBetween(1, 10);

            RuleFor(line => line.GradeThree)
                .NotEmpty()
                .InclusiveBetween(1, 10);

            RuleFor(line => line.GradeFour)
                .NotEmpty()
                .InclusiveBetween(1, 10);

            RuleFor(line => line.Labs)
                .NotEmpty()
                .InclusiveBetween(0, 15);

            RuleFor(line => line.Seminars)
                .NotEmpty()
                .InclusiveBetween(0, 15);

            RuleFor(line => line.Courses)
                .NotEmpty()
                .InclusiveBetween(0, 15);
        }
    }
}
