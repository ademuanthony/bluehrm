using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.LeaveModule.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Leave.Models;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Leave.Controllers
{
    public class EntitlementsController : BlueHrmControllerBase
    {
        private ILeaveService _leaveService;

        public EntitlementsController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }
        // GET: Leave/Types
        public ActionResult Index()
        {
            ViewBag.LeaveTypeId = new SelectList(_leaveService.GetLeaveTypes().Items, "Id", "Name");
            ViewBag.PeriodId = new SelectList(_leaveService.GetLeavePeriods().Items.OrderBy(s=>s.StatDate), "Id", "Range");
            return View();
        }


        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new LeaveEntitlementDto();
            if (id != null)
            {
                try
                {
                    output = _leaveService.GetLeaveEntitlement(new GetLeaveEntitlementInput {LeaveEntitlementId = id.Value});
                }
                catch (Exception exception)
                {
                    //ignored 444
                }
            }

            ViewBag.LeaveTypeId = new SelectList(_leaveService.GetLeaveTypes().Items, "Id", "Name");
            ViewBag.PeriodId = new SelectList(_leaveService.GetLeavePeriods().Items, "Id", "Range");

            var viewModel = new CreateOrEditLeaveEntitlmentModel(output, id == null || id == 0);

            return PartialView(viewModel);
        }

    }
}