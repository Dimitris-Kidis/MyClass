using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Improvement : BaseEntity
    {
        public string HelpNote { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
