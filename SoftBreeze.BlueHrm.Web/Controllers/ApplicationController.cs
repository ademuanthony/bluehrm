using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;

namespace SoftBreeze.BlueHrm.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ApplicationController : BlueHrmControllerBase
    {
        [DisableAuditing]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new {area = "Admin"});
        }
    }
}