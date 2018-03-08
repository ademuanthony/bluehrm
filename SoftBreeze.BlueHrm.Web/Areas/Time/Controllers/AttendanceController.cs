using SoftBreeze.BlueHrm.PersonalInformation;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;
using SoftBreeze.BlueHrm.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Timing;
using SoftBreeze.BlueHrm.TimeModule;
using SoftBreeze.BlueHrm.TimeModule.Dto;
using Tony.Common.Infrastructure;

namespace SoftBreeze.BlueHrm.Web.Areas.Time.Controllers
{
    public class AttendanceController : BlueHrmControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITimeService _timeService;

        public AttendanceController(IEmployeeService employeeService, ITimeService timeService)
        {
            _employeeService = employeeService;
            _timeService = timeService;
        }

        // GET: Time/Attendance
        public ActionResult Index()
        {
            try
            {
                var employee = _employeeService.GetEmployee();
                ViewBag.EmployeeNumber = employee.Number;

            }
            catch
            {
                ViewBag.EmployeeNumber = string.Empty;
            }
            return View();
        }
        
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new AttendanceDto { Date = Clock.Now, ClockIn = Clock.Now };
            if (id != null)
            {
                try
                {
                    output = _timeService.GetAttendanceDto(new GetAttendanceDtoInput { AttendanceId = id.Value });
                }
                catch (Exception exception)
                {
                    //ignored 444
                }
            }


            var viewModel = new SaveAttendanceInput
            {
                Date = output.Date,
                HourIn = output.ClockIn != null ? output.ClockIn.Value.Hour : 0,
                MuniteIn = output.ClockIn != null ? output.ClockIn.Value.Minute : 0,
                HourOut = output.ClockOut != null ? output.ClockOut.Value.Hour : 0,
                MuniteOut = output.ClockOut != null ? output.ClockOut.Value.Minute : 0,
                EmployeeNumber =
                    output.EmployeeId != 0
                        ? _employeeService.GetEmployee(new GetEmployeeInput { EmployeeId = output.EmployeeId }).Number
                        : "",
                Id = id
            };

            var muniteNumbers = new List<string> { "" };
            for (var i = 0; i <= 60; i++) muniteNumbers.Add(StringMethods.RoundOff(i.ToString(), 2));

            var hourNumbers = new List<string> { "" };
            for (var i = 0; i <= 23; i++) hourNumbers.Add(StringMethods.RoundOff(i.ToString(), 2));


            ViewBag.CheckInHour = new SelectList(hourNumbers, viewModel.HourIn);
            ViewBag.CheckInMunite = new SelectList(muniteNumbers, viewModel.MuniteIn);
            ViewBag.CheckOutHour = new SelectList(hourNumbers, viewModel.HourOut);
            ViewBag.CheckOutMunite = new SelectList(muniteNumbers, viewModel.MuniteOut);

            return PartialView(viewModel);
        }

        public ActionResult Report()
        {
            return View();
        }
    }
}