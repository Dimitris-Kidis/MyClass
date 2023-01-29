using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Text { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public int Target { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
