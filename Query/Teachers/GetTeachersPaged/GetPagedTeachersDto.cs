using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetTeachersPaged
{
    public class GetPagedTeachersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset SignedUpAt { get; set; }
        public int NumberOfSubjects { get; set; }
        public int NumberOfClasses { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Experience { get; set; }
    }
}
