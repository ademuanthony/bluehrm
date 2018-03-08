using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.Users;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : BlueHrmControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly UserManager _userManager;

        public UsersController(IUserAppService userAppService, UserManager userManager)
        {
            _userAppService = userAppService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateOrEditModal(long? id)
        {
            var output = await _userAppService.GetUserForEdit(new NullableIdInput<long> {Id = id});
            var viewModel = new CreateOrEditUserModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> PermissionsModal(long id)
        {
            var user = await _userManager.GetUserByIdAsync(id);
            var output = await _userAppService.GetUserPermissionsForEdit(new IdInput<long>(id));
            var viewModel = new UserPermissionsEditViewModel(output, user);

            return PartialView("_PermissionsModal", viewModel);
        }
    }
}