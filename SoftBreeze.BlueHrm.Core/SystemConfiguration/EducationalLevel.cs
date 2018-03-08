using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public class EducationalLevel:AuditedEntity
    {
        public string Name { get; set; }
    }
}
