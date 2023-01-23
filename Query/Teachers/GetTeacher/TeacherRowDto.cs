using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetTeacher
{
    public class TeacherRowDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Experience { get; set; }
    }
}
