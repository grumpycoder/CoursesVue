using Courses.Infrastructure;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace Courses.Web.Controllers.api
{
    [RoutePrefix("api/careertech")]
    public class CareerTechController : ApiController
    {

        private readonly CareerTechDbContext _context;


        public CareerTechController()
        {
            _context = CareerTechDbContext.Create();
        }

        [HttpDelete, Route("programs/{programId}/{courseId}")]
        public async Task<object> RemoveProgramCourse(int programId, int courseId)
        {

            var link = await _context.ProgramCourses.FirstOrDefaultAsync(x => x.CourseId == courseId && x.ProgramId == programId);

            if (link == null) return NotFound();

            _context.ProgramCourses.Remove(link);

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
