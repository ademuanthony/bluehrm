using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class EducationLevelDto:AuditedEntityDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateOrEditEducationLevelInput
    {
        [Required]
        public EducationLevelDto EducationLevel { get; set; }
    }

    public class GetEducationLevelInput
    {
        [Required]
        public int EducationLevelId { get; set; }
    }

    public class DeleteEducationLevelInput
    {
        [Required]
        public int EducationLevelId { get; set; }
    }
}
