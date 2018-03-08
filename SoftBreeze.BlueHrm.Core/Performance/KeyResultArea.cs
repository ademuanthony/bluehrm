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
    public class KeyResultArea:AuditedEntity
    {
        public int PerformanceId { get; set; }
        public int AttributeId { get; set; }
        public int? Rating { get; set; }
        public string ActualAcheivement { get; set; }
        public string Comment { get; set; }

        [ForeignKey("PerformanceId")]
        public StaffPerformance Performance { get; set; }
        
        [ForeignKey("AttributeId")]
        public PerformanceIndicator Attribute { get; set; }
    }

    public class KeyResultAreaDo
    {
        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public int AttributeId { get; set; }
        public int? Rating { get; set; }
        public string ActualAcheivement { get; set; }
        public string Comment { get; set; }

        public string Kpi { get; set; }
    }
}
