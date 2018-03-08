using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm
{
    public class Attachement:AuditedEntity
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Note { get; set; }
    }
}
