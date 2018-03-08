using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization.Users.Profile;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Profile;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : Controller
    {
        private readonly IProfileAppService _profileAppService;

        public ProfileController(IProfileAppService profileAppService)
        {
            _profileAppService = profileAppService;
        }

        public async Task<PartialViewResult> MySettingsModal()
        {
            var output = await _profileAppService.GetCurrentUserProfileForEdit();
            var viewModel = new MySettingsViewModel(output);

            return PartialView("_MySettingsModal", viewModel);
        }

        public PartialViewResult ChangePictureModal(long employeeId = 0)
        {
            ViewBag.EmployeeId = employeeId;
            return PartialView("_ChangePictureModal");
        }

        public PartialViewResult ChangePasswordModal()
        {
            return PartialView("_ChangePasswordModal");
        }
    }
}