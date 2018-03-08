using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.People;
using SoftBreeze.BlueHrm.People.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Mpa.Models.PhoneBook;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_PhoneBook)]
    public class PhoneBookController : BlueHrmControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PhoneBookController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        public ActionResult Index(GetPeopleInput input)
        {
            var output = _personAppService.GetPeople(input);
            var model = new IndexViewModel(output, input.Filter);

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson)]
        public PartialViewResult CreatePersonModal()
        {
            return PartialView("_CreatePersonModal");
        }
        
        [HttpPost]
        public async Task<PartialViewResult> AddPhone(AddPhoneInput input)
        {
            PhoneInPersonListDto phoneInPersonList = await _personAppService.AddPhone(input);
            var model = new PhoneRowInPersonListViewModel(phoneInPersonList);

            return PartialView("_PhoneRowInPersonList", model);
        }
    }
}