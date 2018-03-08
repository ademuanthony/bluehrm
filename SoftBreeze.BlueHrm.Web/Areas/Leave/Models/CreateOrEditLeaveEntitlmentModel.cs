using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.LeaveModule.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Leave.Models
{
    public class CreateOrEditLeaveEntitlmentModel
    {
        public CreateOrEditLeaveEntitlmentModel(LeaveEntitlementDto input, bool isNew)
        {
            IsEditMode = !isNew;
            LeaveEntitlement = input;
        }

        public bool IsEditMode { get; set; }

        public LeaveEntitlementDto LeaveEntitlement { get; set; }
    }
}