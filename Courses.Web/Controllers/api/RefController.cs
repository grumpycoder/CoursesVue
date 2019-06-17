using AutoMapper.QueryableExtensions;
using Courses.Core.Dtos;
using Courses.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace Courses.Web.Controllers.Api
{
    [RoutePrefix("api/ref")]
    public class RefController : ApiController
    {
        private readonly CourseDbContext _context;

        public RefController()
        {
            _context = CourseDbContext.Create();
        }

        [HttpGet, Route("schoolyears")]
        public object SchoolYears()
        {
            var list = _context.SchoolYears.ToList();
            return Ok(list);
        }

        [HttpGet, Route("grades")]
        public object Grades()
        {
            var list = _context.Grades.ToList();
            return Ok(list);
        }

        [HttpGet, Route("courseTypes")]
        public object CourseTypes()
        {
            var list = _context.CourseTypes.ToList();
            return Ok(list);
        }

        [HttpGet, Route("creditTypes")]
        public object CreditTypes()
        {
            var list = _context.CreditTypes.ToList();
            return Ok(list);
        }

        [HttpGet, Route("classTypes")]
        public object ClassTypes()
        {
            var list = _context.ClassTypes.ToList();
            return Ok(list);
        }

        [HttpGet, Route("subjectAreas")]
        public object SubjectAreas()
        {
            var list = _context.SubjectAreas.ToList();
            return Ok(list);
        }

        [HttpGet, Route("programs")]
        public object Programs()
        {
            var list = _context.Programs.ProjectTo<ProgramDto>().ToList();
            return Ok(list);
        }

        [HttpGet, Route("clustertypes")]
        public object ClusterTypes()
        {
            var list = _context.ClusterTypes.ToList();
            return Ok(list);
        }

        [HttpGet, Route("programTypes")]
        public object ProgramTypes()
        {
            var list = _context.ProgramTypes.ToList();
            return Ok(list);
        }

        [HttpGet, Route("credentials")]
        public object Credentials()
        {
            var list = _context.Credentials.ToList();
            return Ok(list);
        }

        [HttpGet, Route("clusters")]
        public object Clusters()
        {
            var list = _context.Clusters.ToList();
            return Ok(list);
        }

        [HttpGet, Route("credentialtypes")]
        public object CredentialTypes()
        {
            var list = _context.CredentialTypes.ToList();
            return Ok(list);
        }

    }
}
