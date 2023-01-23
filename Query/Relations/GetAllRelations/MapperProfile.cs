using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Relations.GetAllRelations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RelationDto, RelationDto>();
            CreateMap<IEnumerable<RelationDto>, IEnumerable<RelationDto>>();
        }
    }
}
