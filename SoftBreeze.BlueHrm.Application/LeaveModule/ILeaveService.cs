using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.LeaveModule.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public interface ILeaveService:IApplicationService
    {
        OutputBase SaveLeaveType(SaveLeaveTypeInput input);
        LeaveTypeDto GetLeaveType(GetLEaveTypeInput input);
        ListResultOutput<LeaveTypeDto> GetLeaveTypes();
        OutputBase DeleteLeaveType(DeleteLeaveTypeInput input);


        ListResultOutput<LeavePeriodDto> GetLeavePeriods();


        OutputBase SaveEntitlement(SaveLeaveEntitlementInput input);
        OutputBase DeleteEntitlement(DeleteLeaveEntitlementInput input);
        LeaveEntitlementDto GetLeaveEntitlement(GetLeaveEntitlementInput input);
        ListResultOutput<LeaveEntitlementDto> GetLeaveEntitlements(GetLeaveEntitlementsInput input);
        ListResultOutput<LeaveEntitlementDo> GetLeaveEntitlementDos(GetLeaveEntitlementsInput input);
        Task<PagedResultOutput<LeaveDo>> GetLeaves(GetLeavesInput input);
        LeaveDo GetLeaveDo(GetLeaveDoInput input);
        OutputBase AssignLeave(AssignLeaveInput input);
        OutputBase DeleteLeave(DeleteLeaveInput input);

        OutputBase MakeLeaveRequest(MakeLeaveRequestInput input);
        OutputBase DeleteLeaveRequest(DeleteLeaveRequestInput input);
        OutputBase ApproveLeaveRequest(ApproveLeaveRequestInput input);
        OutputBase RejectLeaveRequest(RejectLeaveRequestInput input);
        LeaveRequestDto GetLeaveRequestDto(GetLeaveRequestInput input);
        int GetPendingLeaveRequestCount();
        Task<PagedResultOutput<LeaveRequestDo>> GetLeaveRequests(GetLeaveRequestsInput input);
    }
}
