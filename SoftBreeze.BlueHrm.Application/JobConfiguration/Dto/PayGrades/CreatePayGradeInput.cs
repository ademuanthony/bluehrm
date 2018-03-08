using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades
{
    public class CreatePayGradeInput:IInputDto
    {
        [Required]
        public string Name { get; set; }
    }
}
