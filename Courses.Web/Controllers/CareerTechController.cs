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
        public ActionResult Clusters(string clusterCode)
        {
            return View((object)clusterCode);
        }

        [Route("programs/{programCode?}")]
        public ActionResult Programs(string programCode)
        {
            return View((object)programCode);
        }


        [Route("credentials/{credentialCode?}")]
        public ActionResult Credentials(string credentialCode)
        {
            return View((object)credentialCode);
        }

        [Route("courses")]
        public ActionResult Courses()
        {
            return View();
        }

    }
}