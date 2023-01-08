using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Teachers.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, int>
    {
        private readonly IClassRepository<Teacher> _teachersRepository;
        private readonly IUserRepository<User> _usersRepository;
        public DeleteTeacherCommandHandler(
            IClassRepository<Teacher> teachersRepository,
            IUserRepository<User> userRepo
            )
        {
            _teachersRepository = teachersRepository;
            _usersRepository = userRepo;
        }
        public Task<int> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            if (!_usersRepository.GetAll().Any(user => user.Id == request.UserId)) return Task.FromResult(-1);
            var user = _usersRepository.GetByIdAsync(request.UserId);
            var teacherId = user.Result.TeacherId;
            var teacher = _teachersRepository.GetByIdAsync((int)teacherId).Result;

            if (user != null)
            {
                _usersRepository.Delete(user.Result);
                _usersRepository.Save();

                _teachersRepository.Delete(teacher);
                _teachersRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}
