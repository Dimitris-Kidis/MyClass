using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Improvements.GetAllImprovements
{
    public class ImprovementDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTimeOffset Time { get; set; }
        public string ImprovementText { get; set; }
    }
}
