using System;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.LeaveModule
{ 
    public class LeavePeriod:AuditedEntity
    {
        public DateTime StatDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Range
        {
            get { return string.Format("{0} - {1}", StatDate.ToShortDateString(), EndDate.ToShortDateString()); }
        }
    }
}
