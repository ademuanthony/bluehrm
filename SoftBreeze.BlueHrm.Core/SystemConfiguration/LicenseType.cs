using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.SystemConfiguration
{
    public class LicenseType:AuditedEntity
    {
        public string Name { get; set; }
    }
}
