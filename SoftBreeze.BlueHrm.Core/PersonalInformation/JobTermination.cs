using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using SoftBreeze.BlueHrm.JobConfiguration;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class JobTermination:AuditedEntity<long>
    {
        public int ReasonId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        [ForeignKey("Id")]
        public Employee Employee { get; set; }

        [ForeignKey("ReasonId")]
        public JobTerminationReason Reason { get; set; }
    }
}
