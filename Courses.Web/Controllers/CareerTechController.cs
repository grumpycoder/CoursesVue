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

        [Route("clusters/{clusterCode?}")]
        public ActionResult Clusters(string clusterCode = null)
        {
            return View(clusterCode);
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