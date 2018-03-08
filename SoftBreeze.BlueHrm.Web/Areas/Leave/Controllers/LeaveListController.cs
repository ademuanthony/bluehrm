using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.LeaveModule.Dto;
using SoftBreeze.BlueHrm.Organisation;
using SoftBreeze.BlueHrm.Web.Areas.Leave.Models;

namespace SoftBreeze.BlueHrm.Web.Areas.Leave.Controllers
{
    public class LeaveListController : Controller
    {
        private ILeaveService _leaveService;
        private readonly IOrganisationService _organisationService;

        public LeaveListController(ILeaveService leaveService, IOrganisationService organisationService)
        {
            _leaveService = leaveService;
            _organisationService = organisationService;
        }
        // GET: Leave/Types
        public ActionResult Index()
        {
            ViewBag.Status = new SelectList(new List<LeaveStatus>
            {
                LeaveStatus.All,
                LeaveStatus.PendingApproval,
                LeaveStatus.Approved,
                LeaveStatus.Scheduled,
                LeaveStatus.Taken,
                LeaveStatus.Canceled
            });
            ViewBag.Subunits = new SelectList(_organisationService.GetUnits().Items.OrderBy(s=>s.Name), "Id", "Name");
            return View();
        }


        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new LeaveDo();
            if (id != null)
            {
                try
                {
                    output = _leaveService.GetLeaveDo(new GetLeaveDoInput {LeaveId = id.Value});
                }
                catch (Exception exception)
                {
                    //ignored 444
                }
            }

            ViewBag.LeaveTypeId = new SelectList(_leaveService.GetLeaveTypes().Items, "Id", "Name");

            var viewModel = new CreateOrEditLeaveModel(output, id == null || id == 0);

            return PartialView(viewModel);
        }

    }
}