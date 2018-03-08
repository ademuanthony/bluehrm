using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeMemberships
{
    public class EmployeeMembershipDto: AuditedEntityDto
    {
        public long EmployeeId { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipSuscriptionPayer SuscriptionPayer { get; set; }
        public double SuscriptionAmount { get; set; }
        public int CurrencyId { get; set; }
        public DateTime? SuscriptionStartDate { get; set; }
        public DateTime? SuscriptionRenewalDate { get; set; }
        public string Comment { get; set; }

    }

    public class SaveEmployeeMembershipInput : IInputDto
    {
        public EmployeeMembership EmployeeMembership { get; set; }
    }

    public class GetEmployeeMembershipInput : IInputDto
    {
        [Required]
        public int EmployeeMembershipId { get; set; }
    }

    public class GetEmployeeMembershipsInput : IInputDto
    {
        [Required]
        public int EmployeeId { get; set; }
    }

    public class DeleteEmployeeMembershipInput : IInputDto
    {
        [Required]
        public int EmployeeMembershipId { get; set; }
    }

}
