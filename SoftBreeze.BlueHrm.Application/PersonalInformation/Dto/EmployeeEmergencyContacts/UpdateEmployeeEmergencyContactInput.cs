using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts
{
    public class UpdateEmployeeEmergencyContactInput:AuditedEntityDto
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }

        public int EmployeeId { get; set; }
    }
}
