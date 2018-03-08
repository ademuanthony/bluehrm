using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBreeze.BlueHrm.LeaveModule;

namespace SoftBreeze.BlueHrm.Web.Areas.Leave.Models
{
    public class CreateOrEditLeaveModel
    {
        public CreateOrEditLeaveModel(LeaveDo input, bool isNew)
        {
            IsEditMode = !isNew;
            Leave = input;
        }

        public bool IsEditMode { get; set; }

        public LeaveDo Leave { get; set; }
    }
}