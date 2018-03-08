using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeMemberships;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Models
{
    public class CreateOrEditMembershipModel
    {
        public CreateOrEditMembershipModel(EmployeeMembershipDto input, bool isNew)
        {
            IsEditMode = !isNew;
            EmployeeMembership = input;
        }

        public bool IsEditMode { get; set; }

        public EmployeeMembershipDto EmployeeMembership { get; set; }
    }
}