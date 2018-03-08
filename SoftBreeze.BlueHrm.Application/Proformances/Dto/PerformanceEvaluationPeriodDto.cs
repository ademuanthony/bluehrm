using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.Proformances.Dto
{
    public class PerformanceEvaluationPeriodDto:EntityDto
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

    public class GetPerformanceEvaluationPeriodInput : IInputDto
    {
        public int PeriodId { get; set; }
    }
}
