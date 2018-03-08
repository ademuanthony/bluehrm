using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveType:AuditedEntity
    {
        public string Name { get; set; }
        public bool IsEntitlementSituational { get; set; }
    }
}
