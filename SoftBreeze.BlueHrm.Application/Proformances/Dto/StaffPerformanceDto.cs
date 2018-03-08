using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.Proformances.Dto
{
    public class StaffPerformanceDto:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public int PeriodId { get; set; }
        public string AttitudeToWork { get; set; }
        public string MostImportantAreasForImprovment { get; set; }
        public string OtherImportantComment { get; set; }
        public PerformanceEvaluationStatus Status { get; set; }
    }

    public class SaveStaffPerformanceInput : IInputDto
    {
        public StaffPerformanceDto Performance { get; set; }
    }

    public class GetStaffPerformanceInput : IInputDto
    {
        public int PerformanceId { get; set; }
    }
}
