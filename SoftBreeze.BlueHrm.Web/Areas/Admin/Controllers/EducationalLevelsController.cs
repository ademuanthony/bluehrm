using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Qualification;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class EducationalLevelsController : Controller
    {
        private readonly IQualificationService _service;

        public EducationalLevelsController(IQualificationService service)
        {
            _service = service;
        }

        // GET: Admin/Skills
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new EducationLevelDto();
            if (id != null)
            {
                output = _service.GetEducationLevel(new GetEducationLevelInput{ EducationLevelId = id.Value });
            }
            var viewModel = new CreateOrEditEducationalLevelModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}