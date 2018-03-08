using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.Organization;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class JobInformation:AuditedEntity<long>
    {
        public int JobId { get; set; }
        public int StatusId { get; set; }
        public int JobCategoryId { get; set; }
        public DateTime JoinDate { get; set; }
        public int LocationId { get; set; }
        public int UnitId { get; set; }

        [ForeignKey("Id")]
        public Employee Employee { get; set; }

        [ForeignKey("JobId")]
        public Job Job { get; set; }

        [ForeignKey("StatusId")]
        public EmploymentStatus EmploymentStatus { get; set; }

        [ForeignKey("JobCategoryId")]
        public JobCategory JobCategory { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
    }
}
