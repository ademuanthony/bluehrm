using SoftBreeze.BlueHrm.LeaveModule.Dto;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Supervisor;

namespace SoftBreeze.BlueHrm.Web.Areas.Leave.Models
{
    public class CreateOrEditLeaveTypeModel
    {
        public CreateOrEditLeaveTypeModel(LeaveTypeDto input, bool isNew)
        {
            IsEditMode = !isNew;
            LeaveType = input;
        }

        public bool IsEditMode { get; set; }

        public LeaveTypeDto LeaveType { get; set; }
    }
}