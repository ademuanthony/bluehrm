using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Immigrations
{
    public class ImmigrationDto:AuditedEntityDto
    {
        public ImmigrationDocument Document { get; set; }
        public string Number { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string EligibleStatus { get; set; }
        public DateTime? EligibleReviewDate { get; set; }
        public string Comment { get; set; }

        public long EmployeeId { get; set; }
    }

    public class GetImmigrationInput:IInputDto
    {
        [Required]
        public int ImmigrationId { get; set; }
    }

    public class GetImmigrationsInput:IInputDto
    {
        [Required]
        public long EmployeeId { get; set; }
    }

    public class DeleteImmigrationInput : IInputDto
    {
        [Required]
        public int ImmigrationId { get; set; }
    }
}
