using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Configuration.Host;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Settings)]
    public class HostSettingsController : BlueHrmControllerBase
    {
        private readonly IHostSettingsAppService _hostSettingsAppService;

        public HostSettingsController(IHostSettingsAppService hostSettingsAppService)
        {
            _hostSettingsAppService = hostSettingsAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _hostSettingsAppService.GetAllSettings();

            return View(output);
        }
    }
}