using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Models.JobConfiguration;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Controllers
{
    public class PayGradesController : Controller
    {
        private readonly IJobConfigurationService _service;

        public PayGradesController(IJobConfigurationService service)
        {
            _service = service;
        }
        // GET: Admin/PayGrades
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new PayGradeDto();
            if (id != null)
            {
                output = _service.GetPayGrade(new GetPayGradeInput { PayGradeId = id.Value });
            }
            var viewModel = new CreateOrEditPaygradeViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}