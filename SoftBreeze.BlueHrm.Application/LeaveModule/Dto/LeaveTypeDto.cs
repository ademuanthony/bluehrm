using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule.Dto
{
    public class LeaveTypeDto:AuditedEntityDto
    {
        public string Name { get; set; }
        public bool IsEntitlementSituational { get; set; }
    }
     
    public class SaveLeaveTypeInput : IInputDto
    {
        public LeaveType LeaveType { get; set; }
    }

    public class GetLEaveTypeInput : IInputDto
    {
        public int LeaveTypeId { get; set; }
    }

    public class DeleteLeaveTypeInput : IInputDto
    {
        public int LeaveTypeId { get; set; }
    }
}
