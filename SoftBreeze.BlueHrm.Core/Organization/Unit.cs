using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.Organization
{
    public class Unit:AuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Unit Parent { get; set; }
    }
}
