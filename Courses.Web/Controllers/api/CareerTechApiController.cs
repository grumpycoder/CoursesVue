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
        private readonly CourseDbContext _courseContext;

        public CareerTechApiController()
        {
            _context = CareerTechDbContext.Create();
            _courseContext = CourseDbContext.Create();
        }

        [HttpGet, Route("clusters/{clusterCode}")]
        public async Task<object> Cluster(string clusterCode)
        {
            var dto = await _context.Clusters.Include(x => x.Programs).FirstOrDefaultAsync(x => x.ClusterCode == clusterCode);
            return Ok(dto);
        }

        [HttpGet, Route("clusters/{clusterCode}/programs")]
        public async Task<object> GetClusterPrograms(string clusterCode)
        {
            var dto = await _context.Programs
                .Where(x => x.Cluster.ClusterCode == clusterCode)
                .ProjectTo<ProgramDto>().ToListAsync();

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

        [HttpGet, Route("credentials/{credentialCode}/edit")]
        public async Task<object> GetEditCredential(string credentialCode)
        {
            //var schoolYear = 2017;
            var dto = await _context.Credentials
                   .ProjectTo<CredentialEditDto>()
                .Where(x => x.CredentialCode == credentialCode).FirstOrDefaultAsync();
            return Ok(dto);
        }

        [HttpGet, Route("courses/{courseCode}/programs")]
        public async Task<object> GetCoursePrograms(string courseCode)
        {
            //var schoolYear = 2017;
            var dto = await _context.Programs
                .Where(x => x.ProgramCourses.Any(c => c.Course.CourseCode == courseCode))
                .ProjectTo<ProgramDto>()
                .ToListAsync();

            return Ok(dto);
        }


        [HttpGet, Route("credentials/{credentialCode}/programs")]
        public async Task<object> GetEditCredentialPrograms(string credentialCode)
        {
            //var schoolYear = 2017;
            var dto = await _context.Programs
                .Where(x => x.Credentials.Any(c => c.Credential.CredentialCode == credentialCode))
                .ProjectTo<ProgramDto>()
                .ToListAsync();

            return Ok(dto);
        }

        [HttpPut, Route("credentials")]
        public async Task<object> PutCredential(CredentialEditDto dto)
        {
            var credential = await _context.Credentials.FindAsync(dto.Id);

            Mapper.Map(dto, credential);

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

        [HttpPost, Route("programs/{programCode}/course/{courseCode}")]
        public async Task<object> AddProgramCourse(string programCode, string courseCode)
        {

            var existing =
                _context.ProgramCourses.Any(x => x.Program.ProgramCode == programCode && x.Course.CourseCode == courseCode);

            if (existing) return BadRequest("Course already assigned to program");

            var program = _context.Programs.FirstOrDefault(x => x.ProgramCode == programCode);

            if (program == null) return NotFound();

            var course = _courseContext.Courses.FirstOrDefault(x => x.CourseCode == courseCode);

            if (course == null) return NotFound();

            var link = new ProgramCourse()
            {
                CourseId = course.Id,
                ProgramId = program.Id,
                ModifyUser = "mlawrence" //TODO: Get auth user
            };
            _context.ProgramCourses.Add(link);

            await _context.SaveChangesAsync();

            var dto = Mapper.Map<CourseDto>(course);

            return Ok(dto);

        }

        [HttpDelete, Route("programs/{programCode}/course/{courseCode}")]
        public async Task<object> RemoveProgramCourse(string programCode, string courseCode)
        {

            var link = await _context.ProgramCourses
                .FirstOrDefaultAsync(x => x.Course.CourseCode == courseCode && x.Program.ProgramCode == programCode);

            if (link == null) return NotFound();

            _context.ProgramCourses.Remove(link);

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
