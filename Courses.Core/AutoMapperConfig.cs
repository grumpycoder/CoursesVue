using AutoMapper;
using Courses.Core;
using System.Reflection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AutoMapperConfig), "Configure")]
namespace Courses.Core
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(Assembly.GetExecutingAssembly());
                //cfg.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
            });

        }

    }
}
