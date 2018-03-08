using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule.Dto
{
    public class LeaveEntitlementDto:AuditedEntityDto
    {
        public long EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; }
        public int PeriodId { get; set; }
    }

    public class SaveLeaveEntitlementInput:IInputDto
    {
        [Required]
        public LeaveEntitlementDto LeaveEntitlement { get; set; }
    }

    public class DeleteLeaveEntitlementInput : IInputDto
    {
        [Required]
        public int LeaveEntitlementId { get; set; }
    }

    public class GetLeaveEntitlementInput : IInputDto
    {
        [Required]
        public int LeaveEntitlementId { get; set; }
    }

    public class GetLeaveEntitlementsInput : IInputDto
    {
        public long? EmployeeId { get; set; }

        public string EmployeeNumber { get; set; }
        public int? LeaveTypeId { get; set; }
        public int? PeriodId { get; set; }
    }
}
