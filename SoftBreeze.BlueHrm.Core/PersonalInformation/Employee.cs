using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using SoftBreeze.BlueHrm.Authorization.Users;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class Employee:AuditedEntity<long>
    {
        public string Number { get; set; }
        public DateTime? DateEmployed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Fullname { get { return string.Format("{0} {1} {2}", FirstName, LastName, MiddleName); } }
        public Gender Gender { get; set; }
        public MarritalStatus MarritalStatus { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DriversLicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public EmployeeStatus Status { get; set; }

        public string Username { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }

        public JobInformation JobInformation { get; set; }
        public Contact Contact { get; set; }
        public JobTermination JobTermination { get; set; }

        public IEnumerable<EmployeeAttachement> Attachements { get; set; } 
        public IEnumerable<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public IEnumerable<Dependant> Dependants { get; set; } 
        public IEnumerable<Education> Educations { get; set; } 
        public IEnumerable<Immigration> Immigrations { get; set; } 
        public IEnumerable<EmployeeLanguage> Languages { get; set; } 
        public IEnumerable<JobExperience> JobExperiences { get; set; } 
        public IEnumerable<EmployeeMembership> Memberships { get; set; } 
        public IEnumerable<EmployeeSkill> Skills { get; set; } 
        public ICollection<Supervisor> Supervisors { get; set; }
        public ICollection<Supervisor> Subordinates { get; set; }  
    }
}
