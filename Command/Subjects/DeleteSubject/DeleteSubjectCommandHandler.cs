using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Subjects.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, int>
    {
        private readonly IClassRepository<Subject> _subjectRepository;
        public DeleteSubjectCommandHandler(
            IClassRepository<Subject> subjectRepository
            )
        {
            _subjectRepository = subjectRepository;
        }
        public Task<int> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            if (!_subjectRepository.GetAll().Any(subject => subject.Id == request.SubjectId)) return Task.FromResult(-1);
            var subject = _subjectRepository.GetByIdAsync(request.SubjectId);

            if (subject != null)
            {
                _subjectRepository.Delete(subject.Result);
                _subjectRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}
