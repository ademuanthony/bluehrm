using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.PersonalInformation;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : BlueHrmControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILeaveService _leaveService;

        public DashboardController(IEmployeeService employeeService, ILeaveService leaveService)
        {
            _employeeService = employeeService;
            _leaveService = leaveService;
        }

        public ActionResult Index()
        {
            var model = new DashboardViewModel
            {
                EmployeeCount = _employeeService.GetEmployeeCount(),
                LeaveRequestCount = _leaveService.GetPendingLeaveRequestCount()
            };
            return View(model);
        }
    }
}