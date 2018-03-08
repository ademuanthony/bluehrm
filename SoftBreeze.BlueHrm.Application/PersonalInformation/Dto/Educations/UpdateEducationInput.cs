using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Educations
{
    public class UpdateEducationInput:AuditedEntityDto, IInputDto
    {
        [Required]
        public int EmployeeId { get; set; }
        public string Institution { get; set; }
        public string Specialization { get; set; }
        public int Year { get; set; }
        public string Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
