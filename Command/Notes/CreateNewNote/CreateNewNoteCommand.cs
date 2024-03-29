﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Notes.CreateNewNote
{
    public class CreateNewNoteCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string NoteText { get; set; }
    }
}
