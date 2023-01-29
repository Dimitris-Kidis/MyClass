using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Posts.UpdatePost
{
    public class UpdatePostCommand : IRequest<int>
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public int Target { get; set; }
    }
}
