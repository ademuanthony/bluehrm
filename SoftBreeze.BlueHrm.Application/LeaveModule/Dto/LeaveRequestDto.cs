using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using SoftBreeze.BlueHrm.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule.Dto
{
    public class LeaveRequestDto:AuditedEntityDto
    {
        public LeaveRequestDto()
        {
            Status = LeaveRequestStatus.Pending;
        }
        public long EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public LeaveRequestStatus Status { get; set; }
    }

    public class MakeLeaveRequestInput: IInputDto
    {
        public LeaveRequestDto LeaveRequest { get; set; }
    }

    public class GetLeaveRequestInput: IInputDto
    {
        public int LeaveRequestId { get; set; }
    }

    public class GetLeaveRequestsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string EmployeeNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LeaveRequestStatus? Status { get; set; }

        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Employee";
            }
        }
    }

    public class DeleteLeaveRequestInput: IInputDto
    {
        public int LeaveRequestId { get; set; }
    }

    public class ApproveLeaveRequestInput : IInputDto
    {
        public int LeaveRequestId { get; set; }
    }

    public class RejectLeaveRequestInput : IInputDto
    {
        public int LeaveRequestId { get; set; }
    }
}
