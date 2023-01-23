using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminAboutInfo
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AdminAboutInfoDto, AdminAboutInfoDto>();
        }
    }
}
