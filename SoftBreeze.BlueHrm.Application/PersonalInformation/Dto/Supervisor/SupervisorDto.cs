using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Supervisor
{
    public class SupervisorDto:AuditedEntityDto
    {
        public long EmployeeId { get; set; }
        public long SupervisorId { get; set; }
        public EmployeeReportMethod ReportMethod { get; set; }
    }

    public class GetSupervisorInput:IInputDto
    {
        [Required]
        public int SupervisorId { get; set; }
    }

    public class DeleteSupervisorInput : IInputDto
    {
        [Required]
        public int SupervisorId { get; set; }
    }

    public class GetSupervisorsInput : IInputDto
    {
        [Required]
        public long EmployeeId { get; set; }
    }

    public class GetSubordinatesInput : IInputDto
    {
        [Required]
        public long EmployeeId { get; set; }
    }
}
