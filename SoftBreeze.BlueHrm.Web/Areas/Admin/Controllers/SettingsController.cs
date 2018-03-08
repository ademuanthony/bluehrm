using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Configuration.Startup;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Configuration.Tenants;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Tenant_Settings)]
    public class SettingsController : BlueHrmControllerBase
    {
        private readonly ITenantSettingsAppService _tenantSettingsAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public SettingsController(ITenantSettingsAppService tenantSettingsAppService, IMultiTenancyConfig multiTenancyConfig)
        {
            _tenantSettingsAppService = tenantSettingsAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _tenantSettingsAppService.GetAllSettings();
            ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            return View(output);
        }
    }
}