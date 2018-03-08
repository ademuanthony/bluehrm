using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.JobConfiguration.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Qualification;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class QualificationController : Controller
    {
        private readonly IQualificationService _service;

        public QualificationController(IQualificationService service)
        {
            _service = service;
        }
        
        // GET: Admin/Qualification
        public ActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> CreateOrEditSkillModal(int? id)
        {
            var output = new SkillDto();
            if (id != null)
            {
                output = _service.GetSkill(new GetSkillInput {SkillId = id.Value});
            }
            var viewModel = new CreateOrEditSkillModel(output);

            return PartialView("_CreateOrEditSkillModal", viewModel);
        }
    }
}