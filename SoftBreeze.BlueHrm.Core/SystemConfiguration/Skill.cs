using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public class Skill:AuditedEntity
    {
        public string Name { get; set; }
    }
}
