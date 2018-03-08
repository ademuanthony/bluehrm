using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.Performance
{
    public class StaffPerformance:AuditedEntity
    {
        public StaffPerformance()
        {
            Status = PerformanceEvaluationStatus.Started;
        }
        public long EmployeeId { get; set; }
        public int PeriodId { get; set; }
        public string AttitudeToWork { get; set; }
        public string MostImportantAreasForImprovment { get; set; }
        public string OtherImportantComment { get; set; }
        public PerformanceEvaluationStatus Status { get; set; }


        [ForeignKey("PeriodId")]
        public PerformanceEvaluationPeriod Period { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public IEnumerable<KeyResultArea> KeyResultAreas { get; set; } 
        public IEnumerable<ConcludingRemark> ConcludingRemarks { get; set; }
    }
}
