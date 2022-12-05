using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetAllClassmates
{
    public class ClassmatesDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
