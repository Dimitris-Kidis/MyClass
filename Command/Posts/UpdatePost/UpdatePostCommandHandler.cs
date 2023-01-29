using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Posts.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int>
    {
        private readonly IClassRepository<Post> _postsRepository;
        public UpdatePostCommandHandler(IClassRepository<Post> postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _postsRepository
                .FindBy(post => post.Id == request.Id)
                .FirstOrDefault();
            if (post != null)
            {
                post.Target = request.Target;
                post.Text = request.Text;
                post.Header = request.Header;
                post.Author = request.Author;

                _postsRepository.Update(post);
                _postsRepository.Save();
            }
            else
            {
                return Task.FromResult(-1);
            }

            return Task.FromResult(0);
        }
    }
}
