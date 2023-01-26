using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Classes.DeleteClass
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, int>
    {
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<Student> _studentRepository;
        private readonly IUserRepository<User> _userRepository;
        public DeleteClassCommandHandler(
            IClassRepository<Class> classRepository,
            IClassRepository<Student> studentRepository,
            IUserRepository<User> userRepository
            )
        {
            _classRepository = classRepository;
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public Task<int> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var clas = _classRepository.FindBy(clas => clas.Id == request.ClassId).FirstOrDefault();

            var studs = _studentRepository.FindBy(stud => stud.ClassId == request.ClassId).Select(s => s.Id).ToList();
            var users = _userRepository.GetAll().ToList();

            var deleted = _userRepository.FindBy(us => studs.Contains((int)us.StudentId)).ToList();

            _userRepository.DeleteRange(deleted);
            _userRepository.Save();


            var studsToDelete = _studentRepository.FindBy(stud => stud.ClassId == request.ClassId).ToList();

            _studentRepository.DeleteRange(studsToDelete);
            _studentRepository.Save();

            if (clas != null)
            {
                _classRepository.Delete(clas);
                _classRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}
