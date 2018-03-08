using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Dependant:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public RelationshipType Relationship { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
