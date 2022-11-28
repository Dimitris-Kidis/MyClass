using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int Number { get; set; }
        public ICollection<Lesson> Lessons { get; set; } 
    }
}
