using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SoftBreeze.BlueHrm.PersonalInformation;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;
using SoftBreeze.BlueHrm.Proformances;
using SoftBreeze.BlueHrm.Proformances.Dto;
using SoftBreeze.BlueHrm.Web.Areas.Performance.Models;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Performance.Controllers
{
    public class RecordController : BlueHrmControllerBase
    {
        private readonly IStaffPerformanceService _staffPerformanceService;
        private readonly IEmployeeService _employeeService;
        public RecordController(IStaffPerformanceService staffPerformanceService, IEmployeeService employeeService)
        {
            _staffPerformanceService = staffPerformanceService;
            _employeeService = employeeService;
        }
        // GET: Performance/Record
        public ActionResult Index()
        {
            ViewBag.Periods = new SelectList(_staffPerformanceService.GetPerformanceEvaluationPeriods().Items, "Id", "Range");
            return View();
        }

        public ActionResult Details(string id, int periodId)
        {
            var employee = _employeeService.GetEmployeeByNumber(new GetEmployeeByNumberInput {Number = id});
            var period =
                _staffPerformanceService.GetPerformanceEvaluationPeriod(new GetPerformanceEvaluationPeriodInput
                {
                    PeriodId = periodId
                });
            var performance = _staffPerformanceService.GetPerformance(employee.Id, period.Id, true);
            return View("Details",
                new PerformanceReportDetailsViewModel
                {
                    Employee = employee,
                    Period = period,
                    StaffPerformance = performance
                });
        }


        public async Task<PartialViewResult> CreateOrEditKiaRcordModal(int? id)
        {
            var output = new KeyResultAreaDto();
            if (id != null)
            {
                try
                {
                    output =
                        _staffPerformanceService.GetKeyResultArea(new GetKraInput { 
                            KraId = id.Value
                        });
                }
                catch (Exception exception)
                {
                    //ignored
                }
            }
            var viewModel = new CreateOrEditKeyResultAreaModel(output, id == null || id == 0);

            ViewBag.AttributeId = new SelectList(_staffPerformanceService.GetKeyResultAreaAttributes().Items, "Id", "Name");
            ViewBag.Ratings = new SelectList(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            return PartialView(viewModel);
        }

    }
}