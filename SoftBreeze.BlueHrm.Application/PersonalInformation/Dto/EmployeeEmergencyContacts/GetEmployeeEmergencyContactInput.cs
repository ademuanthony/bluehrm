using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts
{
    public class GetEmployeeEmergencyContactInput:IInputDto
    {
        [Required]
        public int EmployeeEmergencyContactId { get; set; }
    }
}
