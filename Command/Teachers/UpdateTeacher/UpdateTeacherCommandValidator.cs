using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Teachers.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            var genderConditions = new List<string>() { "M", "F" };

            RuleFor(user => user.Id)
                .NotEmpty();

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .MinimumLength(5)
                .MaximumLength(30);

            RuleFor(user => user.FirstName)
                .NotEmpty().MinimumLength(2)
                .MaximumLength(30);

            RuleFor(user => user.LastName)
                .NotEmpty().MinimumLength(2)
                .MaximumLength(30);

            RuleFor(user => user.Position)
                .NotEmpty().MinimumLength(2)
                .MaximumLength(30);

            RuleFor(user => user.Experience)
                .NotEmpty().MinimumLength(2)
                .MaximumLength(30);

            RuleFor(user => user.Description)
                .NotEmpty().MinimumLength(50)
                .MaximumLength(400);

            RuleFor(user => user.Gender)
                .NotEmpty()
                .Must(conditions =>
                    genderConditions.Contains(conditions)).WithMessage("Please only use: " + String.Join(", ", genderConditions));
        }
    }
}
