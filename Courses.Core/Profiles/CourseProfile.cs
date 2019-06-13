using AutoMapper;
using Courses.Core.Dtos;
using Courses.Core.Models;
using System.Linq;

namespace Courses.Core.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {

            CreateMap<CourseEditDto, Course>()
                .ForMember(d => d.BeginServiceYearId, opt => opt.MapFrom(s => s.BeginServiceYearId))
                .ForMember(d => d.EndServiceYearId, opt => opt.MapFrom(s => s.EndServiceYearId))
                .ForMember(d => d.LowGradeId, opt => opt.MapFrom(s => s.LowGradeId))
                .ForMember(d => d.HighGradeId, opt => opt.MapFrom(s => s.HighGradeId))
                .ReverseMap();

            CreateMap<Course, CourseDto>()
                .ForMember(d => d.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
                .ForMember(d => d.CreditType, opt => opt.MapFrom(src => src.CreditType.Name))
                .ForMember(d => d.CourseType, opt => opt.MapFrom(src => src.CourseType.Name))
                .ForMember(d => d.ClassType, opt => opt.MapFrom(src => src.ClassType.Description))
                .ForMember(d => d.SubjectArea, opt => opt.MapFrom(src => src.SubjectArea.Name))
                .ForMember(d => d.LowGrade, opt => opt.MapFrom(src => src.LowGrade.Name))
                .ForMember(d => d.HighGrade, opt => opt.MapFrom(src => src.HighGrade.Name))
                .ForMember(d => d.Programs, opt => opt.MapFrom(src => src.ProgramCourses.Select(x => x.Program)))
                ;
        }
    }
}
