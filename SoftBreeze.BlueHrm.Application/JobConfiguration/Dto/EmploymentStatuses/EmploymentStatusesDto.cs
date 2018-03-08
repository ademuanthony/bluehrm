using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses
{
    public class EmploymentStatusDto:EntityDto
    {
        [Required]
        public string Name { get; set; }
    }
}
