using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminsPaged
{
    public class GetPagedAdminsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset SignedUpAt { get; set; }
    }
}
