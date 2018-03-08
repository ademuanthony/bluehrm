using Abp.Domain.Entities.Auditing;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.Organization
{
    public class Location:AuditedEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Notes { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
