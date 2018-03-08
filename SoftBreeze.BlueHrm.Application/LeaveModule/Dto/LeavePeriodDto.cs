using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.LeaveModule.Dto
{
    public class LeavePeriodDto:AuditedEntityDto
    {
        public DateTime StatDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Range
        {
            get { return string.Format("{0} - {1}", StatDate.ToShortDateString(), EndDate.ToShortDateString()); }
        }
    }
}
