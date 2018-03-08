using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace SoftBreeze.BlueHrm.Performance
{
    public class PerformanceEvaluationPeriod:Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Range
        {
            get
            {
                return string.Format("{0} to {1}", StartDate.ToShortDateString(),
                    EndDate.ToShortDateString());
            }
        }
    }
}
