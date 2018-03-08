using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class JobCategoriesController : Controller
    {
        private readonly IJobConfigurationService _service;

        public JobCategoriesController(IJobConfigurationService service)
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
            var output = new JobCategoryDto(); 
            if (id != null)
            {
                output = _service.GetJobCategory(new GetJobCategoryInput { CategoryId = id.Value });
            }
            var viewModel = new CreateOrEditJobCategoryViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}