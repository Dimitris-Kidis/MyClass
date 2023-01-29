using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Posts.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<IEnumerable<PostDto>>
    {
        public int Target { get; set; }
    }
}
