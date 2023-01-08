using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Students.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IUserRepository<User> _usersRepository;
        public UpdateStudentCommandHandler(IUserRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.FindBy(x => x.Id == request.Id).FirstOrDefault();
            if (user != null)
            {
                user.Email = request.Email;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Gender = request.Gender;
                user.DateOfBirth = request.DateOfBirth;

                _usersRepository.Update(user);
                _usersRepository.Save();
            }
            else
            {
                return Task.FromResult(-1);
            }

            return Task.FromResult(0);
        }
    }
}
