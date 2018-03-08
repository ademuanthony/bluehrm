using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class EmployeeStatusesController : Controller
    {
        private readonly IJobConfigurationService _service;

        public EmployeeStatusesController(IJobConfigurationService service)
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
            var output = new EmploymentStatusDto();
            if (id != null)
            {
                output = _service.GetEmploymentStatus(new GetEmploymentStatusInput {Id = id.Value});
            }
            var viewModel = new CreateOrEditEmployeeStatusViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}