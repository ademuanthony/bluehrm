using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Qualification;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class SkillsController : Controller
    {
        private readonly IQualificationService _service;

        public SkillsController(IQualificationService service)
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
            var output = new SkillDto();
            if (id != null)
            {
                output = _service.GetSkill(new GetSkillInput {SkillId = id.Value});
            }
            var viewModel = new CreateOrEditSkillModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}