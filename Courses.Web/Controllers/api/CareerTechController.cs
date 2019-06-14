using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses.Core.Dtos;
using Courses.Core.Models;
using Courses.Infrastructure;
using System.Data.Entity;
using System.Linq;
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

        [HttpGet, Route("clusters/{clusterCode}")]
        public async Task<object> Cluster(string clusterCode)
        {
            var dto = await _context.Clusters.Include(x => x.Programs).FirstOrDefaultAsync(x => x.ClusterCode == clusterCode);
            return Ok(dto);
        }

        [HttpGet, Route("clusters/{clusterCode}/edit")]
        public async Task<object> GetEdit(string clusterCode)
        {
            var dto = await _context.Clusters.ProjectTo<ClusterEditDto>().FirstOrDefaultAsync(x => x.ClusterCode == clusterCode);

            return Ok(dto);
        }

        [HttpGet, Route("clusters/{clusterCode}/edit/full")]
        public async Task<object> GetEditFull(string clusterCode)
        {
            var dto = await _context.Clusters.Include(x => x.Programs).ProjectTo<ClusterEditFullDto>().FirstOrDefaultAsync(x => x.ClusterCode == clusterCode);

            return Ok(dto);
        }

        [HttpPut, Route("clusters")]
        public async Task<object> Put(ClusterEditDto dto)
        {
            var cluster = await _context.Clusters.FindAsync(dto.Id);

            Mapper.Map(dto, cluster);

            await _context.SaveChangesAsync();

            return Ok(dto);
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

        [HttpPost, Route("programs/{programId}/{courseId}")]
        public async Task<object> AddProgramCourse(int programId, int courseId)
        {

            var existing =
                _context.ProgramCourses.Any(x => x.ProgramId == programId && x.CourseId == courseId);

            if (existing) return BadRequest("Course already assigned to program");

            var link = new ProgramCourse()
            {
                CourseId = courseId,
                ProgramId = programId,
                ModifyUser = "mlawrence" //TODO: Get auth user
            };
            _context.ProgramCourses.Add(link);

            await _context.SaveChangesAsync();

            var dto = _context.Programs.ProjectTo<ProgramDto>()
                .FirstOrDefaultAsync(x => x.ProgramId == programId);

            return Ok(dto);

        }
    }
}
