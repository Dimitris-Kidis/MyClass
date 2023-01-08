using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.ClassesAndTeachers.CreateNewClassTeacherRelationship
{
    public class CreateNewClassTeacherRelationshipCommandValidator : AbstractValidator<CreateNewClassTeacherRelationshipCommand>
    {
        public CreateNewClassTeacherRelationshipCommandValidator()
        {
            RuleFor(clas => clas.ClassId)
                .NotEmpty();

            RuleFor(clas => clas.TeacherId)
                .NotEmpty();

            RuleFor(clas => clas.SubjectId)
                .NotEmpty();
        }
    }
}
