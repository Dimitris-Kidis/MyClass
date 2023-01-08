using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Classes.CreateClass
{
    public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
    {
        public CreateClassCommandValidator()
        {
            RuleFor(clas => clas.ClassName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(30);
        }
    }
}
