using System.Web.Mvc;

namespace Courses.Web.Controllers
{
    [RoutePrefix("courses")]
    public class CourseController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{courseCode}")]
        public ActionResult Detail(string courseCode)
        {
            return View((object)courseCode);
        }

    }
}