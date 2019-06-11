using Courses.Infrastructure;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Courses.Core.Dtos;

namespace Courses.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly CourseDbContext _context;

        public CourseController()
        {
            _context = CourseDbContext.Create();
        }

        [HttpGet, Route("{id}")]
        public async Task<object> Get(int id)
        {
            var dto = await _context.CourseViews.FirstOrDefaultAsync(c => c.Id == id);

            return Ok(dto);
        }

        [HttpGet, Route("{id}/full"), Authorize]
        public async Task<object> GetFull(int id)
        {
            var dto = await _context.Courses
                .Include(x => x.ProgramCourses).ProjectTo<CourseDto>()
                .FirstOrDefaultAsync(c => c.Id == id);
            return Ok(dto);
        }

    }
}
