using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveEntitlementDo
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public int PeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
    }
}
