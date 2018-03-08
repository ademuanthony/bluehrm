using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class License:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int LincenseTypeId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; } 

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("LincenseTypeId")]
        public LicenseType LicenseType { get; set; }
    }
}
