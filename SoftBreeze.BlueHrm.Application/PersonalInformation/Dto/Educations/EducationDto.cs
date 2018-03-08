using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Educations
{
    public class EducationDto:AuditedEntityDto, IValidate
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int LevelId { get; set; }
        public string Institution { get; set; }
        public string Specialization { get; set; }
        public int Year { get; set; }
        public string Score { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class SaveEducationInput:IInputDto
    {
        public EducationDto Education { get; set; }
    }
}
