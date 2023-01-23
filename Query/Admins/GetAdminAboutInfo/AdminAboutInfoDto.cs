using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminAboutInfo
{
    public class AdminAboutInfoDto
    {
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
