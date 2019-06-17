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

        [Route("programs")]
        public ActionResult Programs()
        {
            return View();
        }

        
        [Route("credentials")]
        public ActionResult Credentials()
        {
            return View();
        }

        [Route("courses")]
        public ActionResult Courses()
        {
            return View();
        }

    }
}