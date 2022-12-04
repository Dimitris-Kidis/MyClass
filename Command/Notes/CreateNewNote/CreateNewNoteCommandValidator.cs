using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Notes.CreateNewNote
{
    public class CreateNewNoteCommandValidator : AbstractValidator<CreateNewNoteCommand>
    {
        public CreateNewNoteCommandValidator()
        {
            RuleFor(note => note.NoteText)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(500);
        }
    }
}
