using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.SystemConfiguration.Dto
{
    public class SkillDto:AuditedEntityDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateOrEditSkillInput : IInputDto
    {
        [Required]
        public SkillDto Skill { get; set; }
    }

    public class GetSkillInput:IInputDto
    {
        [Required]
        public int SkillId { get; set; }
    }

    public class DeleteSkillInput:IInputDto
    {
        [Required]
        public int SkillId { get; set; }
    }
}
