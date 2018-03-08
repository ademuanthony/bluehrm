using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public long EmployeeCount { get; set; }
        public int LeaveRequestCount { get; set; }
    }
}