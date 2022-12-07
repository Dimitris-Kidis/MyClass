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
        public ICollection<Grade> Grades { get; set; }
        //public ICollection<AbsentList> AbsentLists { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }



    }
}
