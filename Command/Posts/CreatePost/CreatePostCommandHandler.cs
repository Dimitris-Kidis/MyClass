using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Posts.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IClassRepository<Post> _postsRepository;
        public CreatePostCommandHandler(IClassRepository<Post> postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Header = request.Header,
                Text = request.Text,
                Target = request.Target,
                Author = request.Author,
                UserId = request.UserId
            };

            _postsRepository.Add(newPost);
            _postsRepository.Save();

            var resultId = newPost.Id;
            return Task.FromResult(resultId);
        }
    }
}
