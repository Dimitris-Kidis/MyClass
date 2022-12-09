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

namespace Query.Classes.GetAllClassesWithIds
{
    public class GetAllClassesWithIdsQueryHandler : IRequestHandler<GetAllClassesWithIdsQuery, IEnumerable<ClassDto>>
    {
        private readonly IClassRepository<Class> _classesRepository;
        private readonly IMapper _mapper;

        public GetAllClassesWithIdsQueryHandler(
            IClassRepository<Class> classesRepository,
            IMapper mapper)
        {
            _classesRepository = classesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassDto>> Handle(GetAllClassesWithIdsQuery request, CancellationToken cancellationToken)
        {
            var classes = _classesRepository.GetAll().Select(cl => new ClassDto { Id = cl.Id, ClassName = cl.ClassName }).ToList();
            return classes.Select(_mapper.Map<ClassDto>);
        }
    }
}
