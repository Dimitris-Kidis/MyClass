using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Improvements.CreateNewImprovement
{
    public class CreateNewImprovementCommandHandler : IRequestHandler<CreateNewImprovementCommand, int>
    {
        private readonly IClassRepository<Improvement> _improvementRepository;
        private readonly IUserRepository<User> _userRepository;
        public CreateNewImprovementCommandHandler(IClassRepository<Improvement> improvementRepository, IUserRepository<User> userRepository)
        {
            _improvementRepository = improvementRepository;
            _userRepository = userRepository;
        }
        public Task<int> Handle(CreateNewImprovementCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository
                .GetAll()
                .All(user => user.Id != command.UserId)) return Task.FromResult(-1);

            Improvement imp = new Improvement
            {
                UserId = command.UserId,
                HelpNote = command.HelpNote,
                CreatedAt = DateTimeOffset.Now
            };

            _improvementRepository.Add(imp);
            _improvementRepository.Save();

            var resultId = imp.Id;
            return Task.FromResult(resultId);
        }
    }
}
