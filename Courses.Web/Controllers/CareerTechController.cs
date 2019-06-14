using System.Web.Mvc;

namespace Courses.Web.Controllers
{
    [RoutePrefix("careertech")]
    public class CareerTechController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("clusters")]
        public ActionResult Clusters()
        {
            return View();
        }

    }
}