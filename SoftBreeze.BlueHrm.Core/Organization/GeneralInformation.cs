using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Castle.DynamicProxy;

namespace SoftBreeze.BlueHrm.Organization
{
    public class GeneralInformation:AuditedEntity
    {
        public string OrganisationName { get; set; }
        public string TaxId { get; set; }
        public string RegistrationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Note { get; set; }
    }
}
