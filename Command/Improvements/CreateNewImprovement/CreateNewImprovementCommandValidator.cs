using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Improvements.CreateNewImprovement
{

    public class CreateNewImprovementCommandValidator : AbstractValidator<CreateNewImprovementCommand>
    {
        public CreateNewImprovementCommandValidator()
        {
            RuleFor(note => note.HelpNote)
                .NotEmpty()
                .MinimumLength(20)
                .MaximumLength(200);
        }
    }
}
