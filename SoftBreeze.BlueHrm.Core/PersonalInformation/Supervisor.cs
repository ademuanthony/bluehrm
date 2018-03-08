using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Supervisor:AuditedEntity
    {
        public long EmployeeId { get; set; }
        public long SupervisorId { get; set; }
        public EmployeeReportMethod ReportMethod { get; set; }
        
        //[ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public virtual Employee SupervisingEmployee { get; set; }
    }
}
