using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees
{
    public class UpdateEmployeeInput:AuditedEntityDto, IInputDto
    {
        [Required]
        public string Number { get; set; }
        public DateTime DateEmployed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public MarritalStatus MarritalStatus { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DriversLicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}
