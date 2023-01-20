using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Subjects.GetAllSubjectsWithIds
{
    public class GetAllSubjectsWithIdsQueryHandler : IRequestHandler<GetAllSubjectsWithIdsQuery, IEnumerable<SubjectDto>>
    {
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IMapper _mapper;

        public GetAllSubjectsWithIdsQueryHandler(
            IClassRepository<Subject> subjectsRepository,
            IMapper mapper)
        {
            _subjectsRepository = subjectsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> Handle(GetAllSubjectsWithIdsQuery request, CancellationToken cancellationToken)
        {
            var classes = _subjectsRepository
                .GetAll()
                .Select(cl => new SubjectDto { Id = cl.Id, SubjectName = cl.Name })
                .ToListAsync(cancellationToken)
                .Result;
            return classes.Select(_mapper.Map<SubjectDto>);
        }
    }
}
