using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveEntitlement:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; } 
        public int PeriodId { get; set; }

        [ForeignKey("PeriodId")]
        public LeavePeriod LeavePeriod { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public IEnumerable<Leave> Leaves { get; set; } 
    }
}
