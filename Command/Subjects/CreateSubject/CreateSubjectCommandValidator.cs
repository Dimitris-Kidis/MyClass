using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Subjects.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(subject => subject.SubjectName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(30);
        }
    }
}
