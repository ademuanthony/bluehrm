using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBreeze.BlueHrm.Performance
{
    public class PerfomanceEvaluationStatusDo
    {
        public int PeriodId { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public PerformanceEvaluationStatus Status { set; get; }
        public DateTime? StartDate { get; set; }
    }
}
