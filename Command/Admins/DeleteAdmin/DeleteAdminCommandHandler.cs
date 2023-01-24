using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Admins.DeleteAdmin
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, int>
    {
        private readonly IClassRepository<Student> _studsRepository;
        private readonly IUserRepository<User> _usersRepository;
        public DeleteAdminCommandHandler(
            IClassRepository<Student> studsRepository,
            IUserRepository<User> userRepo
            )
        {
            _studsRepository = studsRepository;
            _usersRepository = userRepo;
        }
        public Task<int> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            if (!_usersRepository.GetAll().Any(user => user.Id == request.UserId)) return Task.FromResult(-1);
            var user = _usersRepository.GetByIdAsync(request.UserId);

            if (user != null)
            {
                _usersRepository.Delete(user.Result);
                _usersRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}
