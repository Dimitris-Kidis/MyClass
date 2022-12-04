using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Notes.DeleteNoteById
{
    public class DeleteNoteByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
