using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class JobTerminationReasonsController : Controller
    {

        private readonly IJobConfigurationService _service;

        public JobTerminationReasonsController(IJobConfigurationService service)
        {
            _service = service;
        }

        // GET: Admin/JobTitles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new JobTerminationReasonDto();
            if (id != null)
            {
                output =
                    _service.GetJobTerminationReason(new GetJobTerminationReasonInput
                    {
                        JobTerminationReasonId = id.Value
                    });
            }
            var viewModel = new CreateOrEditJobTerminationReasonViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}