using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts
{
    public class DeleteEmployeeEmergencyContactInput
    {
        [Required]
        public int EmployeeEmergencyContactId { get; set; }
    }
}
