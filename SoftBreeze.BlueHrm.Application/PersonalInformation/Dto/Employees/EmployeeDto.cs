using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SoftBreeze.BlueHrm.Authorization.Users.Dto;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Contacts;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees
{
    public class EmployeeDto:AuditedEntityDto<long>
    {
        public string Number { get; set; }
        public DateTime? DateEmployed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Fullname { get { return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName); } }
        public Gender Gender { get; set; }
        public MarritalStatus MarritalStatus { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DriversLicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public ContactDto Contact { get; set; }
    }

    public class EmployeeAutoCompleteDto
    {
        public string Label { get; set; }
        public long Value { get; set; }
    }
}
