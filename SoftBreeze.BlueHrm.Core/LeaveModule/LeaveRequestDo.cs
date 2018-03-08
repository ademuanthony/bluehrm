using System;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveRequestDo:AuditedEntityDto
    {
        public string Employee { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public LeaveRequestStatus Status { get; set; }
    }
}
