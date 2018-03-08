using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBreeze.BlueHrm
{
    public static class EnumExtenssions
    {
        public static string ToString(this LeaveStatus status)
        {
            switch (status)
            {
                case LeaveStatus.All:
                    return "All";
                case LeaveStatus.Approved:
                    return "Approved";
                case LeaveStatus.Canceled:
                    return "Cancelled";
                case LeaveStatus.PendingApproval:
                    return "Pending Approval";
                case LeaveStatus.Scheduled:
                    return "Scheduled";
                case LeaveStatus.Taken:
                    return "Taken";
            }
            return string.Empty;
        }
    }
}
