using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Posts.GetOnePost
{
    public class GetOnePostQueryHandler : IRequestHandler<GetOnePostQuery, OnePostDto>
    {
        private readonly IClassRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetOnePostQueryHandler(
            IClassRepository<Post> postRepository,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<OnePostDto> Handle(GetOnePostQuery request, CancellationToken cancellationToken)
        {
            var post = _postRepository.FindBy(post => post.Id == request.PostId).FirstOrDefault();

            var postInfo = new OnePostDto
            {
                Id = post.Id,
                Text = post.Text,
                Header = post.Header,
                Author = post.Author,
                Target = post.Target
            };

            return _mapper.Map<OnePostDto>(postInfo);
        }
    }
}
