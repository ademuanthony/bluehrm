using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.LeaveModule.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Leave.Models;

namespace SoftBreeze.BlueHrm.Web.Areas.Leave.Controllers
{
    public class TypesController : Controller
    {
        private ILeaveService _leaveService;

        public TypesController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }
        // GET: Leave/Types
        public ActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new LeaveTypeDto();
            if (id != null)
            {
                try
                {
                    output = _leaveService.GetLeaveType(new GetLEaveTypeInput { LeaveTypeId = id.Value });
                }
                catch (Exception exception)
                {
                    //ignored
                }
            }
            var viewModel = new CreateOrEditLeaveTypeModel(output, id == null || id == 0);

            return PartialView(viewModel);
        }


    }
}