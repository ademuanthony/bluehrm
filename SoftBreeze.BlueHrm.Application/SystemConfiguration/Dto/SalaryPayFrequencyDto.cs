using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class SalaryPayFrequencyDto:EntityDto, IInputDto
    {
        public string Name { get; set; }
    }

    public class GetSalaryPayFrequencyInput
    {
        public int SalaryPayFrequencyId { get; set; }
    }
}
