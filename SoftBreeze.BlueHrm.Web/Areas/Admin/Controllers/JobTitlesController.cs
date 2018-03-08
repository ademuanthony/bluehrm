using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Roles;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class JobTitlesController : Controller
    {
        private readonly IJobConfigurationService _service;

        public JobTitlesController(IJobConfigurationService service)
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
            var output = new JobDto();
            if (id != null)
            {
                output = _service.GetJob(new GetJobInput {JobId = id.Value});
            }
            var viewModel = new CreateOrEditJobViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}