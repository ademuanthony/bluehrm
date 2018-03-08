using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Contacts;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Dependants;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Educations;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeAttachements;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeMemberships;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Immigrations;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.JobInfo;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Salaries;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Supervisor;

namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public interface IEmployeeService:IApplicationService
    {
        //Contacts 
        OutputBase SaveContact(SaveContactInput input);
        OutputBase CreateContact(CreateContactInput input);
        OutputBase UpdateContact(UpdateContactInput input);
        ContactDto GetContact(GetContactInput input);

        //Job Information
        OutputBase SaveJobInformation(JobInformationDto input);
        JobInformationDto GetJobInformation(GetJobInformationInput input);

        //Dependants
        OutputBase CreateOrEditDependant(DependantDto dependant);
        OutputBase CreateDependant(CreateDependantInput input);
        OutputBase DeleteDependant(DeleteDependantInput input);
        DependantDto GetDependant(GetDependantInput input);
        ListResultOutput<DependantDto> GetDependants(GetDependantsInput input);

        //Education
        OutputBase SaveEducation(SaveEducationInput input);
        OutputBase CreateEducation(CreateEducationInput input);
        OutputBase UpdateEduction(UpdateEducationInput input);
        OutputBase DeleteEduction(DeleteEducationInput input);
        EducationDto GetEducation(GetEducationInput input);
        ListResultOutput<EducationDto> GetEducations(GetEducationsInput input);

        //Employee
        Task<OutputBase> CreateEmployee(CreateEmployeeInput input);
        OutputBase UpdateEmployee(UpdateEmployeeInput input);
        OutputBase DeleteEmployee(DeleteEducationInput input);
        EmployeeDto GetEmployee();
        EmployeeDto GetEmployee(GetEmployeeInput input);
        EmployeeDto GetEmployeeByNumber(GetEmployeeByNumberInput input);
        List<EmployeeDto> GetEmployees();
        long GetEmployeeCount();
        Task<PagedResultOutput<EmployeeDto>> GetEmployees(GetEmployeesInput input);
        Task<List<EmployeeAutoCompleteDto>> Search(string term);

        //Employee Attachment
        OutputBase CreateEmployeeAttachment(CreateEmployeeAttachementInput input);
        OutputBase DeleteEmployeeAttachment(DeleteEmployeeAttachementInput input);
        List<EmployeeAttachementDto> GetEmployeeAttachements(GetEmployeeAttachmentsInput input);

        //Employee Emergency Contact
        OutputBase CreateOrEditEmergencyContact(EmployeeEmergencyContactDto input);
        OutputBase CreateEmployeeEmergencyContact(CreateEmployeeEmergencyContactInput input);
        OutputBase UpdateEmployeeEmergencyContact(EmployeeEmergencyContactDto input);
        OutputBase DeleteEmployeeEmergencyContact(DeleteEmployeeEmergencyContactInput input);
        EmployeeEmergencyContactDto GetEmployeeEmergencyContact(GetEmployeeEmergencyContactInput input);
        ListResultOutput<EmployeeEmergencyContactDto> GetEmployeeEmergencyContacts(GetEmployeeEmergencyContactsInput input);

        //Immigration
        OutputBase CreateOrEditImmigration(ImmigrationDto immigration);
        OutputBase DeleteImmigration(DeleteImmigrationInput input);
        ImmigrationDto GetImmigration(GetImmigrationInput input);
        ListResultOutput<ImmigrationDto> GetImmigrations(GetImmigrationsInput input);

        //salary
        OutputBase SaveSalary(SalaryDto salary);
        SalaryDto GetSalary(GetSalaryInput input);
        ListResultOutput<SalaryDto> GetSalaries(GetSalariesInput input);
        ListResultOutput<SalaryViewDo> GetSalaryViews(GetSalariesInput input);
        OutputBase DeleteSalary(DeleteSalaryInput input);

        //supervisor
        OutputBase AddSupervisor(SupervisorDto supervisor);
        OutputBase DeleteSupervisor(DeleteSupervisorInput input);
        SupervisorDto GetSupervisor(GetSupervisorInput input);
        ListResultOutput<SupervisorDto> GetSupervisors(GetSupervisorsInput input);
        ListResultOutput<SupervisorDto> GetSubordinates(GetSupervisorsInput input);
        ListResultOutput<SupervisorDo> GetSubOrdinates(GetSupervisorsInput input);
        ListResultOutput<SupervisorDo> GetSupervisorDos(GetSupervisorsInput input);

        //Membership
        OutputBase SaveEmployeeMembership(SaveEmployeeMembershipInput input);
        EmployeeMembershipDto GetEmployeeMembership(GetEmployeeMembershipInput input);
        ListResultOutput<EmployeeMembershipDto> GetEmployeeMemberships(GetEmployeeMembershipsInput input);
        OutputBase DeleteEmployeeMemebership(DeleteEmployeeMembershipInput input);
    }
}
