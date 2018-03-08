using System.Web.Mvc;

namespace SoftBreeze.BlueHrm.Web.Controllers
{
    public class HomeController : BlueHrmControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Application");
            //return View();
        }
	}
}