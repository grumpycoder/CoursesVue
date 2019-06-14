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
    public class CareerTechApiController : ApiController
    {
        private readonly CareerTechDbContext _context;

        public CareerTechApiController()
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

        [HttpGet, Route("programs/{programCode}/edit")]
        public async Task<object> GetEditPrograms(int programCode)
        {
            //var schoolYear = 2017;
            var programs = await _context.Programs
                .ProjectTo<ProgramEditDto>()
                .Where(x => x.Id == programCode).FirstOrDefaultAsync();
            return Ok(programs);
        }

        [HttpGet, Route("programs/{programCode}/edit/full")]
        public async Task<object> GetEditProgramsFull(int programCode)
        {
            //var schoolYear = 2017;
            var programs = await _context.Programs
                .Include(x => x.Credentials)
                .Include(x => x.ProgramCourses)
                .ProjectTo<ProgramEditFullDto>()
                .Where(x => x.Id == programCode).FirstOrDefaultAsync();


            return Ok(programs);
        }

        [HttpGet, Route("programs/{programCode}/courses")]
        public async Task<object> GetProgramsCourses(string programCode)
        {
            //var schoolYear = 2017;
            var dto = await _context.ProgramCourses.Where(x => x.Program.ProgramCode == programCode)
                .Select(x => x.Course).ProjectTo<CourseDto>().ToListAsync();
             

            return Ok(dto);
        }

        [HttpPut, Route("programs")]
        public async Task<object> Put(ProgramEditDto dto)
        {
            var program = await _context.Programs.FindAsync(dto.Id);

            Mapper.Map(dto, program);

            await _context.SaveChangesAsync();

            return Ok(dto);
        }

        [HttpDelete, Route("programs/{programCode}/credential/{credentialCode}")]
        public async Task<object> RemoveProgramCredential(string programCode, string credentialCode)
        {

            var pc = await _context.ProgramCredentials.Where(x =>
                x.Program.ProgramCode == programCode && x.Credential.CredentialCode == credentialCode).ToListAsync();

            if (!pc.Any()) return NotFound();

            _context.ProgramCredentials.RemoveRange(pc);

            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpPost, Route("programs/{programCode}/credential/{credentialCode}")]
        public async Task<object> AddProgramCredential(string programCode, string credentialCode)
        {

            var program = await _context.Programs.Include(x => x.Credentials)
                .FirstOrDefaultAsync(x => x.ProgramCode == programCode);

            if (program == null) return NotFound();

            var credential = await _context.Credentials.FirstOrDefaultAsync(x => x.CredentialCode == credentialCode);

            if (credential == null) return NotFound();

            if (program.Credentials.Any(x => x.CredentialId == credential.Id))
            {
                return BadRequest("Credential already assigned");
            }
            
            //TODO: update modify user
            program.Credentials.Add(new ProgramCredential() { Program = program, Credential = credential, ModifiyUser = "mlawrence" });

            await _context.SaveChangesAsync();

            var dto = Mapper.Map<CredentialDto>(credential);
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
