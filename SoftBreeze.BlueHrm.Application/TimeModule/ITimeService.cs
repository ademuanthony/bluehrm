using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.TimeModule.Dto;

namespace SoftBreeze.BlueHrm.TimeModule
{
    public interface ITimeService:IApplicationService
    {
        OutputBase SaveAttendance(SaveAttendanceInput input);
        Task<OutputBase> Clockin(ClockInInput input);
        Task<OutputBase> ClockOut(ClockoutInput input);
        OutputBase DeleteAttendance(DeleteAttanceInput input);
        List<AttendanceDto> GetAttendanceDtos(GetAttendanceDtosInput input);
        ListResultOutput<AttendanceDo> GetAttendanceReports(GetAttendanceReportsInput input);
        AttendanceDto GetAttendanceDto(GetAttendanceDtoInput input);
        Task<PagedResultOutput<AttendanceDo>> GetAttendances(GetAttendanceDtosInput input);
    }
}
