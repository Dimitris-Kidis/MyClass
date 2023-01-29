using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Posts.DeletePost
{
    public class DeletePostCommand : IRequest<int>
    {
        public int PostId { get; set; }
    }
}
