using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Note : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string NoteText { get; set; }
    }
}
