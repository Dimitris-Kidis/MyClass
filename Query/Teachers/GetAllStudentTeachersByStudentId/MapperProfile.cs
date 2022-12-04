using ApplicationCore.Domain.Entities;
using AutoMapper;

namespace Query.Teachers.GetAllStudentTeachersByStudentId
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherListDto, TeacherListDto>();
            CreateMap<IEnumerable<TeacherListDto>, IEnumerable<TeacherListDto>>();
        }
    }
}
