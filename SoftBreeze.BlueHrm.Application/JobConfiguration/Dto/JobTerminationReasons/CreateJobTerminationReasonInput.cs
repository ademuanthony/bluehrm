using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons
{
    public class CreateJobTerminationReasonInput:IInputDto
    {
        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
