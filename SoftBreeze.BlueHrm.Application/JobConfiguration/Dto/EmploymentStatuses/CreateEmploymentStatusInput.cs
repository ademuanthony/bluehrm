using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace BlueHrm.JobConfiguration.Dto
{
    public class CreateEmploymentStatusInput:IInputDto
    {
        public string Name { get; set; }
    }
}
