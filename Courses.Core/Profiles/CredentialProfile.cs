using AutoMapper;
using Courses.Core.Dtos;
using Courses.Core.Models;

namespace Courses.Core.Profiles
{
    public class CredentialProfile : Profile
    {
        public CredentialProfile()
        {
            CreateMap<CredentialEditDto, Credential>();

        }
    }
}
