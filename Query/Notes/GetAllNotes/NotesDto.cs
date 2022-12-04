using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Notes.GetAllNotes
{
    public class NotesDto
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
