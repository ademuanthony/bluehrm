using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.Performance
{
    public class PerformanceIndicator:AuditedEntity
    {
        public string Name { get; set; }
    }
}
