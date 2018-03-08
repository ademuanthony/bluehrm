using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class SalaryCompunentDto:EntityDto,IInputDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class GetSalaryCompunentInput:IInputDto
    {
        [Required]
        public int SalaryCompunentId { get; set; }
    }
}
