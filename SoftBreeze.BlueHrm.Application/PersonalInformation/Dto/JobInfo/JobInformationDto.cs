using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.JobInfo
{
    public class JobInformationDto:AuditedEntityDto<long>, IValidate
    {
        public int JobId { get; set; }
        public int StatusId { get; set; }
        public int JobCategoryId { get; set; }
        public DateTime JoinDate { get; set; }
        public int LocationId { get; set; }
        public int UnitId { get; set; }
    }

    public class GetJobInformationInput : IInputDto
    {
        public long EmployeeId { get; set; }
    }
}
