using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.LeaveModule.Dto;
using SoftBreeze.BlueHrm.Proformances;
using SoftBreeze.BlueHrm.Proformances.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Leave.Models;
using SoftBreeze.BlueHrm.Web.Areas.Performance.Models;

namespace SoftBreeze.BlueHrm.Web.Areas.Performance.Controllers
{
    public class IndicatorsController : Controller
    {
        private readonly IStaffPerformanceService _staffPerformance;
        public IndicatorsController(IStaffPerformanceService staffPerformance)
        {
            _staffPerformance = staffPerformance;
        }
        // GET: Performance/KeyResultAreas
        public ActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new PerformacneIndicatorDto();
            if (id != null)
            {
                try
                {
                    output =
                        _staffPerformance.GetKeyResultAreaAttribute(new GetKeyResultAreaAttributeInput
                        {
                            AttributeId = id.Value
                        });
                }
                catch (Exception exception)
                {
                    //ignored
                }
            }
            var viewModel = new CreateOrEditKeyResultAreaAttributeModel(output, id == null || id == 0);

            return PartialView(viewModel);
        }

    }
}