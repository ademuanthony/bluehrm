using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class Leave:AuditedEntity
    {
        public int EntitlementId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveStatus Status { get; set; }
        public string Comment { get; set; }
        public int NumberOfDays { get; set; }
        [ForeignKey("EntitlementId")]
        public LeaveEntitlement LeaveEntitlment { get; set; }
    }
}
