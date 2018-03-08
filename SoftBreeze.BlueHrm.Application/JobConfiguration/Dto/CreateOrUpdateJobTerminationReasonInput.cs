using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto
{
    public class CreateOrUpdateJobTerminationReasonInput:IInputDto
    {
        public JobTerminationReasonDto JobTerminationReason { get; set; }
    }
}
