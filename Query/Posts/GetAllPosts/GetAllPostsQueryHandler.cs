using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Posts.GetAllPosts
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<PostDto>>
    {
        private readonly IClassRepository<Post> _postsRepository;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler(
            IClassRepository<Post> postsRepository,
            IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            if (request.Target == 4)
            {
                var posts = _postsRepository
                .GetAll()
                .OrderByDescending(post => post.CreatedAt);

                return posts.Select(_mapper.Map<PostDto>);
            }
            else if (request.Target == 2)
            {
                var posts = _postsRepository
                .FindBy(post => post.Target == 2 || post.Target == 3)
                .OrderByDescending(post => post.CreatedAt);

                return posts.Select(_mapper.Map<PostDto>);
            }
            else
            {
                var posts = _postsRepository
                .FindBy(post => post.Target == 1 || post.Target == 3)
                .OrderByDescending(post => post.CreatedAt);

                return posts.Select(_mapper.Map<PostDto>);
            }
        }
    }
}
