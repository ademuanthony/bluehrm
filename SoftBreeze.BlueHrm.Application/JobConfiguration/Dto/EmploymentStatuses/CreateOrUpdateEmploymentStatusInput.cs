using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses
{
    public class CreateOrUpdateEmploymentStatusInput:IInputDto
    {
        public EmploymentStatusDto EmploymentStatus { get; set; }
    }
}
