using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public class BlueHrmLanguage:AuditedEntity
    {
        public string Name { get; set; }
    }
}
