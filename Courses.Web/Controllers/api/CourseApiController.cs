using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses.Core.Dtos;
using Courses.Infrastructure;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Courses.Web.Controllers.Api
{
    [RoutePrefix("api/courses")]
    public class CourseApiController : ApiController
    {
        private readonly CourseDbContext _context;

        public CourseApiController()
        {
            _context = CourseDbContext.Create();
        }

        [HttpGet, Route("")]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            var list = await _context.CourseViews.ToListAsync();

            return Ok(DataSourceLoader.Load(list, loadOptions));
        }

        [HttpGet, Route("{courseCode}")]
        public async Task<object> GetByCode(string courseCode)
        {
            var dto = await _context.CourseViews.FirstOrDefaultAsync(c => c.CourseCode == courseCode);

            return Ok(dto);
        }

        [HttpGet, Route("{courseCode}/full")]
        public async Task<object> GetFull(string courseCode)
        {
            var dto = await _context.Courses
                .Include(x => x.ProgramCourses).ProjectTo<CourseDto>()
                .FirstOrDefaultAsync(c => c.CourseCode == courseCode);
            return Ok(dto);
        }

        [HttpGet, Route("{courseCode}/edit")]
        public async Task<object> GetEdit(string courseCode)
        {
            var dto = await _context.Courses
                .Where(c => c.CourseCode == courseCode).ProjectTo<CourseEditDto>().FirstOrDefaultAsync();

            return Ok(dto);
        }

        [HttpGet, Route("{courseCode}/edit/full")]
        public async Task<object> GetEditFull(string courseCode)
        {
            var dto = await _context.Courses.Include(x => x.ProgramCourses).ProjectTo<CourseEditFullDto>().FirstOrDefaultAsync(c => c.CourseCode == courseCode);

            return Ok(dto);
        }

        [HttpPut, Route("")]
        public async Task<object> Put(CourseEditDto dto)
        {
            var course = await _context.Courses.FindAsync(dto.Id);

            Mapper.Map(dto, course);

            _context.SaveChanges();

            return Ok(dto);
        }


    }
}
