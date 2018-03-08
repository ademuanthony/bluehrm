using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Dependants
{
    public class UpdateDependantInput:AuditedEntityDto, IInputDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public RelationshipType Relationship { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
