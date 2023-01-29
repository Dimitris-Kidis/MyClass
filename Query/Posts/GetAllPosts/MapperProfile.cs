using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Posts.GetAllPosts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<IEnumerable<Post>, IEnumerable<PostDto>>();
        }
    }
}
