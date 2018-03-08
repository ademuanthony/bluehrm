using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveDo
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public int? LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Date
        {

            get
            {
                return StartDate == null
                    ? ""
                    : string.Format("{0} to {1}", StartDate.Value.ToShortDateString(), EndDate.Value.ToShortDateString());
            }
        }

        public LeaveStatus Status { get; set; }
        public string Comment { get; set; }
        public int NumberOfDays { get; set; }
        //public int LeaveBalance { get; set; }
    }
}
