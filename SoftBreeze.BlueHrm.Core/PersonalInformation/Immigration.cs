using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Immigration:AuditedEntity
    {
        public ImmigrationDocument Document { get; set; }
        public string Number { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string EligibleStatus { get; set; }
        public DateTime? EligibleReviewDate { get; set; }
        public string Comment { get; set; }

        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
