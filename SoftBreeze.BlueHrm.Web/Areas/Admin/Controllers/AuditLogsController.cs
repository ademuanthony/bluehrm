using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : BlueHrmControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}