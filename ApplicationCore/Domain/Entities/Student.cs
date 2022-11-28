using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Student : BaseEntity
    {

        public ICollection<User> Users { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public string ClassName { get; set; }


    }
}
