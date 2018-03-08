using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts
{
    public class EmployeeEmergencyContactDto:AuditedEntityDto
    {
        [Required]
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string HomePhoneNumber { get; set; }
        [Required]
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }

        public int EmployeeId { get; set; }
    }
}
