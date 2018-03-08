using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public class JobTerminationReason:AuditedEntity
    {
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
