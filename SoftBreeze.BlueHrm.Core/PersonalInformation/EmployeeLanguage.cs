using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class EmployeeLanguage:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int LanguageId { get; set; }
        public int ProficencyLevel { get; set; }
        

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("LanguageId")]
        public BlueHrmLanguage Language { get; set; }
    }
}
