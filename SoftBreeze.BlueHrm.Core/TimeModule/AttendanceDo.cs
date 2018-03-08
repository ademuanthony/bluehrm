using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBreeze.BlueHrm.TimeModule
{
    public class AttendanceDo
    {
        public int Id { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public string PunchInTime { get { return ClockIn == null ? "" : ClockIn.Value.ToShortTimeString(); } }
        public string PunchOutTime { get { return ClockOut == null ? "" : ClockOut.Value.ToShortTimeString(); } }
    }
}
