using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class EmployeeMembership:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipSuscriptionPayer SuscriptionPayer { get; set; }
        public double SuscriptionAmount { get; set; }
        public int CurrencyId { get; set; }
        public DateTime? SuscriptionStartDate { get; set; }
        public DateTime? SuscriptionRenewalDate { get; set; }
        public string Comment { get; set; }


        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("MembershipTypeId")]
        public Membership MembershipType { get; set; }
        
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
