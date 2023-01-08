using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Subjects.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly IClassRepository<ApplicationCore.Domain.Entities.Subject> _subjectsRepository;
        public CreateSubjectCommandHandler(IClassRepository<ApplicationCore.Domain.Entities.Subject> subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }
        public Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var newSubject = new ApplicationCore.Domain.Entities.Subject
            {
                Name = request.SubjectName
            };

            _subjectsRepository.Add(newSubject);
            _subjectsRepository.Save();

            var resultId = newSubject.Id;
            return Task.FromResult(resultId);
        }
    }
}
