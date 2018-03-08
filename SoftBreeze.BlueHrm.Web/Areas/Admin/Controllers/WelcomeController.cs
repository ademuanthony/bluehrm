using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : BlueHrmControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}