using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Classes.CreateClass
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, int>
    {
        private readonly IClassRepository<ApplicationCore.Domain.Entities.Class> _classRepository;
        public CreateClassCommandHandler(IClassRepository<ApplicationCore.Domain.Entities.Class> classRepository)
        {
            _classRepository = classRepository;
        }
        public Task<int> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            var newClass = new ApplicationCore.Domain.Entities.Class
            {
                ClassName = request.ClassName
            };

            _classRepository.Add(newClass);
            _classRepository.Save();

            var resultId = newClass.Id;
            return Task.FromResult(resultId);
        }
    }
}
