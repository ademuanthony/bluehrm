using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Dependants
{
    public class DependantDto:AuditedEntityDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public RelationshipType Relationship { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
