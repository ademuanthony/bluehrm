using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveRequestComment:AuditedEntity
    {
        public string Comment { get; set; }
        public int RequestId { get; set; }
        public LeaveRequest Request { get; set; } 
    }
}
