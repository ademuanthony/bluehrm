using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditEmergencyContactModel
    {
        public CreateOrEditEmergencyContactModel(EmployeeEmergencyContactDto input, bool isNew)
        {
            IsEditMode = !isNew;
            EmergencyContact = input;
        }

        public bool IsEditMode { get; set; }

        public EmployeeEmergencyContactDto EmergencyContact { get; set; }
    }
}