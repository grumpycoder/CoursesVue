using AutoMapper;
using Courses.Core.Dtos;
using Courses.Core.Models;
using System.Linq;

namespace Courses.Core.Profiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program, ProgramDto>()
                .ForMember(d => d.ProgramId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.ClusterId, opt => opt.MapFrom(src => src.Cluster.Id))
                .ForMember(d => d.ProgramName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.ProgramCode, opt => opt.MapFrom(src => src.ProgramCode))
                .ForMember(d => d.ClusterCode, opt => opt.MapFrom(src => src.Cluster.ClusterCode))
                .ForMember(d => d.ClusterName, opt => opt.MapFrom(src => src.Cluster.Name))
                .ForMember(d => d.Credentials, opt => opt.MapFrom(src => src.Credentials.Select(x => x.Credential)))
                ;

            CreateMap<ProgramEditDto, Program>();

            CreateMap<Credential, CredentialDto>()
                .ForMember(d => d.CredentialTypeName, opt => opt.MapFrom(src => src.CredentialType.Name))
                .ForMember(d => d.CredentialTypeCode, opt => opt.MapFrom(src => src.CredentialType.CredentialTypeCode))
                ;

        }

    }
}
