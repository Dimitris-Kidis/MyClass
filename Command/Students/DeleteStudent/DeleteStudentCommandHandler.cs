using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Services.Repository.UserRepository;

namespace Command.Students.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IClassRepository<Student> _studsRepository;
        private readonly IUserRepository<User> _usersRepository;
        public DeleteStudentCommandHandler(
            IClassRepository<Student> studsRepository,
            IUserRepository<User> userRepo
            )
        {
            _studsRepository = studsRepository;
            _usersRepository = userRepo;
        }
        public Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (!_usersRepository.GetAll().Any(user => user.Id == request.UserId)) return Task.FromResult(-1);
            var user = _usersRepository.GetByIdAsync(request.UserId);
            var studId = user.Result.StudentId;
            var student = _studsRepository.GetByIdAsync((int)studId).Result;

            if (user != null)
            {
                _usersRepository.Delete(user.Result);
                _usersRepository.Save();

                _studsRepository.Delete(student);
                _studsRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}

