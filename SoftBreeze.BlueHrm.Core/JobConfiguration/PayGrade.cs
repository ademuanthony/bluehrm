using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public class PayGrade:AuditedEntity
    {
        public string Name { get; set; }
    }
}
