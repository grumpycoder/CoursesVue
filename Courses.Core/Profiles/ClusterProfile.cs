using AutoMapper;
using Courses.Core.Dtos;
using Courses.Core.Models;

namespace Courses.Core.Profiles
{
    public class ClusterProfile : Profile
    {
        public ClusterProfile()
        {
            CreateMap<ClusterEditDto, Cluster>().ReverseMap();


            CreateMap<Cluster, ClusterEditFullDto>()
                .ForMember(d => d.Programs, opt => opt.MapFrom(s => s.Programs))
                .ReverseMap();
        }
    }
}
