using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Education:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int LevelId { get; set; }
        public string Institution { get; set; }
        public string Specialization { get; set; }
        public int Year { get; set; }
        public string Score { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("LevelId")]
        public EducationalLevel EducationalLevel { get; set; }
    }
}
