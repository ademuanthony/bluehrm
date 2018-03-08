using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.JobConfiguration
{
    public class EmploymentStatus:AuditedEntity
    {
         public string Name { get; set; }
    }
}
