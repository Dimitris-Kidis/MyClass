using System;
using ApplicationCore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Query.Improvements.GetAllImprovements
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Improvement, ImprovementDto>();
            CreateMap<IEnumerable<Improvement>, IEnumerable<ImprovementDto>>();
        }
    }
}
