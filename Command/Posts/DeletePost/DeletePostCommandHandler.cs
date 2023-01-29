using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Posts.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, int>
    {
        private readonly IClassRepository<Post> _postsRepository;
        public DeletePostCommandHandler(IClassRepository<Post> postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public Task<int> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            if (!_postsRepository.GetAll().Any(note => note.Id == request.PostId)) return Task.FromResult(-1);
            var user = _postsRepository.GetByIdAsync(request.PostId);
            if (user != null)
            {
                _postsRepository.Delete(user.Result);
                _postsRepository.Save();
            }
            return Task.FromResult(0);
        }
    }
}
