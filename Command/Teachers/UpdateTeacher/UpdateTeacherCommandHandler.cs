using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Teachers.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, int>
    {
        private readonly IUserRepository<User> _usersRepository;
        private readonly IClassRepository<Teacher> _teachersRepository;
        public UpdateTeacherCommandHandler(
            IUserRepository<User> usersRepository,
            IClassRepository<Teacher> teachersRepository)
        {
            _usersRepository = usersRepository;
            _teachersRepository = teachersRepository;
        }
        public Task<int> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.FindBy(x => x.Id == request.Id).FirstOrDefault();

            var teacherPart = _teachersRepository.FindBy(teacher => teacher.Id == user.TeacherId).FirstOrDefault();
            if (user != null)
            {
                user.Email = request.Email;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Gender = request.Gender;
                user.DateOfBirth = request.DateOfBirth;

                teacherPart.Position = request.Position;
                teacherPart.Experience = request.Experience;
                teacherPart.Description = request.Description;

                _usersRepository.Update(user);
                _usersRepository.Save();

                _teachersRepository.Update(teacherPart);
                _teachersRepository.Save();
            }
            else
            {
                return Task.FromResult(-1);
            }

            return Task.FromResult(0);
        }
    }
}
