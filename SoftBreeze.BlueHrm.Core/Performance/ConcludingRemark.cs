using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.Performance
{
    public class ConcludingRemark:AuditedEntity
    {
        public int PerformanceId { get; set; }
        public string Question { get; set; }
        public bool Answer { get; set; }
        [ForeignKey("PerformanceId")]
        public StaffPerformance Performance { get; set; }
    }
}
