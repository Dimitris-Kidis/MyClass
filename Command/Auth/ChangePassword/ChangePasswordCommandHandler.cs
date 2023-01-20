using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Command.Auth.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository<User> _userRepository;
        public ChangePasswordCommandHandler(UserManager<User> userManager, IUserRepository<User> userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<int> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var myUser = _userRepository.FindBy(user => user.Id == command.UserId).FirstOrDefault();

            if (myUser.Password.Equals(command.NewPassword)) return await Task.FromResult(-1);

            if (!myUser.Password.Equals(command.OldPassword)) return await Task.FromResult(-1);


            myUser.Password = command.NewPassword;
            _userRepository.Update(myUser);
            _userRepository.Save();


            var user = await _userManager.FindByIdAsync($"{command.UserId}");
            await _userManager.ChangePasswordAsync(user, command.OldPassword, command.NewPassword);


            return await Task.FromResult(1);
        }
    }
}
