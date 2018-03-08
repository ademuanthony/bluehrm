using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public class JobCategory:AuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
