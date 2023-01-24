using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Admins.UpdateAdmin
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, int>
    {
        private readonly IUserRepository<User> _usersRepository;
        public UpdateAdminCommandHandler(IUserRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Task<int> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.FindBy(userUpdated => userUpdated.Id == request.Id).FirstOrDefault();
            if (user != null)
            {
                user.Email = request.Email;
                user.UserName = request.Email;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Gender = request.Gender;
                user.DateOfBirth = request.DateOfBirth;

                user.NormalizedUserName = request.Email;
                user.NormalizedEmail = request.Email;
                user.CreatedBy = request.Email;


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
