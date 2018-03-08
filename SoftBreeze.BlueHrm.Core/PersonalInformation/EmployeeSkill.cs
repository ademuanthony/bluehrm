using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class EmployeeSkill:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int YearOfExperience { get; set; }
        public string Comment { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}
