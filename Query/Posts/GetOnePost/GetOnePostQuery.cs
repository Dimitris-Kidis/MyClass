using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Posts.GetOnePost
{
    public class GetOnePostQuery : IRequest<OnePostDto>
    {
        public int PostId { get; set; }
    }
}
