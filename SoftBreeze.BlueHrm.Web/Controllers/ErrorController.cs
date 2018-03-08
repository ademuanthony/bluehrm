using System.Web.Mvc;
using Abp.Auditing;

namespace SoftBreeze.BlueHrm.Web.Controllers
{
    public class ErrorController : BlueHrmControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}