using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Notes.GetAllNotes
{
    public class GetAllNotesByUserIdQuery : IRequest<IEnumerable<NotesDto>>
    {
        public int Id { get; set; }
    }
}
