using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public class Job:AuditedEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string Note { get; set; }
    }
}
