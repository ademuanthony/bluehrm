using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;
using SoftBreeze.BlueHrm.Proformances.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Performance.Models
{
    public class PerformanceReportDetailsViewModel
    {
        public StaffPerformanceDto StaffPerformance { get; set; }
        public EmployeeDto Employee { get; set; }
        public PerformanceEvaluationPeriodDto Period { get; set; }
    }
}