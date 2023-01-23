using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminsPaged
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<PagedAdminsDto, GetPagedAdminsDto>();

            CreateMap<IEnumerable<PagedAdminsDto>, IEnumerable<GetPagedAdminsDto>>();

        }
    }
}
