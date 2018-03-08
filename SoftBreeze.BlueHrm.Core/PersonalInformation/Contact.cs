using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Contact:AuditedEntity<long>
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string WorkEmail { get; set; }
        public string OtherEmail { get; set; }

        [ForeignKey("Id")]
        public Employee Employee { get; set; }
    }
}
