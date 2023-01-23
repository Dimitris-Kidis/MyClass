using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Schedules.CreateSchedule
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            var genderConditions = new List<string>() { "M", "F" };



            RuleFor(schedule => schedule.ClassId)
                .NotEmpty();

            RuleFor(schedule => schedule.TeacherId)
                .NotEmpty();

            RuleFor(schedule => schedule.SubjectId)
                .NotEmpty();

            RuleFor(schedule => schedule.LessonName)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);

            RuleFor(schedule => schedule.Cabinet)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);
        }
    }
}
