using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using AutoMapper;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Contacts;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Dependants;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Educations;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeAttachements;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;

using System.Data.Entity;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNet.Identity;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Authorization.Users.Dto;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeMemberships;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Immigrations;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.JobInfo;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Salaries;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Supervisor;


namespace SoftBreeze.BlueHrm.PersonalInformation
{
    public class EmployeeService : BlueHrmAppServiceBase, IEmployeeService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IDependantRepository _dependantRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeAttachementRepository _employeeAttachementRepository;
        private readonly IEmployeeEmergencyContactRepository _employeeEmergencyContactRepository;
        private readonly IImmigrationRepository _immigrationRepository;
        private readonly ISalaryRepository _salaryRepository;
        private readonly IJobInformationRepository _jobInformationRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IEmployeeMembershipRepository _membershipRepository;

        private readonly IUserAppService _userService;

        public EmployeeService(IContactRepository contactRepository,
            IDependantRepository dependantRepository,
            IEducationRepository educationRepository,
            IEmployeeRepository employeeRepository,
            IEmployeeAttachementRepository employeeAttachementRepository,
            IEmployeeEmergencyContactRepository employeeEmergencyContactRepository,
            IImmigrationRepository immigrationRepository,
            IJobInformationRepository jobInformationRepository,
            ISalaryRepository salaryRepository,
            ISupervisorRepository supervisorRepository,
            IEmployeeMembershipRepository membershipRepository,
            IUserAppService userService
            )
        {
            _contactRepository = contactRepository;
            _dependantRepository = dependantRepository;
            _educationRepository = educationRepository;
            _employeeRepository = employeeRepository;
            _employeeAttachementRepository = employeeAttachementRepository;
            _employeeEmergencyContactRepository = employeeEmergencyContactRepository;
            _immigrationRepository = immigrationRepository;
            _jobInformationRepository = jobInformationRepository;
            _salaryRepository = salaryRepository;
            _supervisorRepository = supervisorRepository;
            _membershipRepository = membershipRepository;
            _userService = userService;
        }


        #region Contacts

        public OutputBase SaveContact(SaveContactInput input)
        {
            try
            {
                if (!_contactRepository.Query(q => q.Any(c => c.Id == input.Contact.Id)))
                {
                    _contactRepository.InsertAndGetId(Mapper.Map<Contact>(input.Contact));
                }
                else
                {
                    _contactRepository.Update(Mapper.Map<Contact>(input.Contact));

                }
                return new OutputBase {Message = "Contact saved", Success = true};
            }
            catch (Exception exception)
            {
                return new OutputBase {Message = "Error in saving contact. " + exception.Message, Success = true};
            }
        }
        public OutputBase CreateContact(CreateContactInput input)
        {
            try
            {
                _contactRepository.Insert(Mapper.Map<Contact>(input));
                return new OutputBase { Message = "Contact saved", Success = true };
            }
            catch
            {
                return new OutputBase { Message = "Contact not saved", Success = false };
            }
        }

        public OutputBase UpdateContact(UpdateContactInput input)
        {
            _contactRepository.Update(Mapper.Map<Contact>(input));
            return new OutputBase { Message = "Contact updated", Success = true };
        }

        public ContactDto GetContact(GetContactInput input)
        {
            return Mapper.Map<ContactDto>(_contactRepository.FirstOrDefault(c=>c.Id == input.ContactId));
        }
        #endregion

        #region Job Detail

        public OutputBase SaveJobInformation(JobInformationDto input)
        {
            try
            {
                if (_jobInformationRepository.Query(q => q.Any(j => j.Id == input.Id)))
                {
                    _jobInformationRepository.Update(Mapper.Map<JobInformation>(input));
                }
                else
                {
                    _jobInformationRepository.Insert(Mapper.Map<JobInformation>(input));
                }
                return new OutputBase {Message = "Job information saved", Success = true};
            }
            catch (Exception exception)
            {
                return new OutputBase {Message = exception.Message, Success = true};
            }
        }

        public JobInformationDto GetJobInformation(GetJobInformationInput input)
        {
            return Mapper.Map<JobInformationDto>(_jobInformationRepository.FirstOrDefault(j => j.Id == input.EmployeeId));
        }

        #endregion

        #region Salary

        public OutputBase SaveSalary(SalaryDto salary)
        {
            if (
                _salaryRepository.Query(
                    q =>
                        q.Any(s => s.SalaryComponentId == salary.SalaryComponentId && s.EmployeeId == salary.EmployeeId && s.Id != salary.Id)))
            {
                return new OutputBase {Message = "You have already made an entry for this salary conpunent", Success = false};
            }
            _salaryRepository.InsertOrUpdate(Mapper.Map<Salary>(salary));
            return new OutputBase {Message = "Conpunent saved", Success = true};
        }

        public SalaryDto GetSalary(GetSalaryInput input)
        {
            return Mapper.Map<SalaryDto>(_salaryRepository.Get(input.SalaryId));
        }

        public ListResultOutput<SalaryDto> GetSalaries(GetSalariesInput input)
        {
            return new ListResultOutput<SalaryDto>(Mapper.Map<List<SalaryDto>>(_salaryRepository.GetAllList(s=>s.EmployeeId == input.EmployeeId)));
        }

        public ListResultOutput<SalaryViewDo> GetSalaryViews(GetSalariesInput input)
        {
            return new ListResultOutput<SalaryViewDo>(_salaryRepository.GetSalaryViewDos(input.EmployeeId).ToList());
        }
        public OutputBase DeleteSalary(DeleteSalaryInput input)
        {
            _salaryRepository.Delete(input.SalaryId);
            return new OutputBase {Message = "Salary Deleted", Success = true};
        }

        #endregion

        #region Dependants

        public OutputBase CreateOrEditDependant(DependantDto dependant)
        {
            _dependantRepository.InsertOrUpdate(Mapper.Map<Dependant>(dependant));
            return new OutputBase {Message = "Dependant added", Success = true};
        }
        public OutputBase CreateDependant(CreateDependantInput input)
        {
            _dependantRepository.Insert(Mapper.Map<Dependant>(input));
            return new OutputBase { Message = "Dependant added", Success = true };
        }

        public OutputBase DeleteDependant(DeleteDependantInput input)
        {
            _dependantRepository.Delete(input.DependantId);
            return new OutputBase { Message = "Dependant deleted", Success = true };
        }

        public DependantDto GetDependant(GetDependantInput input)
        {
            return Mapper.Map<DependantDto>(_dependantRepository.Get(input.DependantId));
        }

        public ListResultOutput<DependantDto> GetDependants(GetDependantsInput input)
        {
            return new ListResultOutput<DependantDto>( Mapper.Map<List<DependantDto>>(_dependantRepository.GetAllList(de => de.EmployeeId == input.EmployeeId)));
        }

        #endregion

        #region Education

        public OutputBase SaveEducation(SaveEducationInput input)
        {
            _educationRepository.InsertOrUpdate(Mapper.Map<Education>(input.Education));
            return new OutputBase {Message = "Saved successfully", Success = true};
        }
        public OutputBase CreateEducation(CreateEducationInput input)
        {
            _educationRepository.Insert(Mapper.Map<Education>(input));
            return new OutputBase { Message = "Education added", Success = true };

        }

        public OutputBase UpdateEduction(UpdateEducationInput input)
        {
            _educationRepository.Update(Mapper.Map<Education>(input));
            return new OutputBase { Message = "Education updated", Success = true };
        }

        public OutputBase DeleteEduction(DeleteEducationInput input)
        {
            _educationRepository.Delete(input.EducationId);
            return new OutputBase { Message = "Education deleted", Success = true };
        }

        public EducationDto GetEducation(GetEducationInput input)
        {
            return Mapper.Map<EducationDto>(_educationRepository.Get(input.EducationId));
        }

        public ListResultOutput<EducationDto> GetEducations(GetEducationsInput input)
        {
            return new ListResultOutput<EducationDto>(
                Mapper.Map<List<EducationDto>>(_educationRepository.GetAllList(ed => ed.EmployeeId == input.EmployeeId)));
        }
        #endregion

        #region Employee

        public async Task<OutputBase> CreateEmployee(CreateEmployeeInput input)
        {
            try
            {
                var employee = input.Employee;
                if (_employeeRepository.Query(q => q.Any(emp => emp.Number == input.Employee.Number)))
                {
                    return new OutputBase
                    {
                        Message = "An employee with the selected number have been added",
                        Success = false
                    };
                }
                //check username
                if (UserManager.FindByName(employee.Username) != null)
                {
                    return new OutputBase { Message = "Selected username is already in use", Success = false };
                }
                if (UserManager.FindByEmail(employee.EmailAddress) != null)
                {
                    return new OutputBase { Message = "Selected email is already in use", Success = false };
                }
                string[] role = {"User"};
                await _userService.CreateOrUpdateUser(new CreateOrUpdateUserInput
                {
                    User = new UserEditDto
                    {
                        EmailAddress = employee.EmailAddress,
                        IsActive = true,
                        Name = employee.FirstName,
                        Surname = employee.LastName,
                        Password = employee.Password,
                        ShouldChangePasswordOnNextLogin = true,
                        UserName = employee.Username
                    },
                    AssignedRoleNames = role
                });

                var user = UserManager.FindByName(employee.Username);
                employee.Id = user.Id;
                employee.DateEmployed = null;
                employee.DateOfBirth = null;
                employee.LicenseExpiryDate = null;

                _employeeRepository.Insert(Mapper.Map<Employee>(employee));
                return new OutputBase {Message = "Employee added", Success = true, Id = employee.Id};
            }
            catch (Exception exception)
            {
                return new OutputBase {Message = exception.Message, Success = false};
            }
        }

        public OutputBase UpdateEmployee(UpdateEmployeeInput input)
        {
            if (_employeeRepository.Query(q => q.Any(emp => emp.Number == input.Number && emp.Id != input.Id)))
            {
                return new OutputBase { Message = "An employee with the selected number have been added", Success = false };
            }
            _employeeRepository.Update(Mapper.Map<Employee>(input));
            return new OutputBase { Message = "Employee updated", Success = true };
        }

        public OutputBase DeleteEmployee(DeleteEducationInput input)
        {
            _employeeRepository.Delete(input.EducationId);
            return new OutputBase { Message = "Employee deleted" };
        }

        public EmployeeDto GetEmployee()
        {
            return GetEmployee(new GetEmployeeInput { EmployeeId = GetCurrentUser().Id });
        }

        public EmployeeDto GetEmployee(GetEmployeeInput input)
        {
            return Mapper.Map<EmployeeDto>(_employeeRepository.Get(input.EmployeeId));
        }

        public EmployeeDto GetEmployeeByNumber(GetEmployeeByNumberInput input)
        {
            return Mapper.Map<EmployeeDto>(_employeeRepository.FirstOrDefault(emp => emp.Number == input.Number));
        }

        public List<EmployeeDto> GetEmployees()
        {
            return Mapper.Map<List<EmployeeDto>>(_employeeRepository.GetAll());
        }

        public long GetEmployeeCount()
        {
            return _employeeRepository.Count();
        }

        public async Task<PagedResultOutput<EmployeeDto>> GetEmployees(GetEmployeesInput input)
        {
            try
            {
                IQueryable<Employee> query;

                if (IsGranted(AppPermissions.Pages_Pim_Eployees_List))
                    query = _employeeRepository.GetAll()
                        .WhereIf(
                            !input.Filter.IsNullOrWhiteSpace(),
                            u =>
                                u.Number.Contains(input.Filter) ||
                                (u.FirstName + " " + u.MiddleName + " " + u.LastName).Contains(input.Filter) ||
                                u.FirstName.Contains(input.Filter) ||
                                u.LastName.Contains(input.Filter) ||
                                u.Contact.MobilePhoneNumber.Contains(input.Filter) ||
                                u.MiddleName.Contains(input.Filter)
                        );
                else
                {

                    var currentEmployeeId = GetCurrentUser().Id;
                    query = _employeeRepository.GetAll().Where(e => e.Id == currentEmployeeId).AsQueryable();
                }

                var employeeCount = await query.CountAsync();
                var emplyeeList = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var emplyeeListDtos = emplyeeList.MapTo<List<EmployeeDto>>();

                return new PagedResultOutput<EmployeeDto>(
                    employeeCount,
                    emplyeeListDtos
                    );
            }
            catch (Exception exception)
            {
                return new PagedResultOutput<EmployeeDto>();
            }

        }

        public async Task<List<EmployeeAutoCompleteDto>> Search(string term)
        {
            var query = _employeeRepository.GetAll()
                               .WhereIf(
                                   !term.IsNullOrWhiteSpace(),
                                   u =>
                                       u.FirstName.StartsWith(term) ||
                                       u.LastName.StartsWith(term) ||
                                       u.MiddleName.StartsWith(term)
                               ).Select(e=>new EmployeeAutoCompleteDto
                               {
                                   Label = e.FirstName + " " + e.MiddleName + " " + e.LastName,
                                   Value = e.Id
                               });
            return query.ToList();
        }
        #endregion

        #region employment attachment

        public OutputBase CreateEmployeeAttachment(CreateEmployeeAttachementInput input)
        {
            _employeeAttachementRepository.Insert(Mapper.Map<EmployeeAttachement>(input));
            return new OutputBase { Message = "Attachment added", Success = true };
        }

        public OutputBase DeleteEmployeeAttachment(DeleteEmployeeAttachementInput input)
        {
            _employeeAttachementRepository.Delete(input.EmployeeAttachementId);
            return new OutputBase { Message = "Attachment deleted", Success = true };
        }

        public List<EmployeeAttachementDto> GetEmployeeAttachements(GetEmployeeAttachmentsInput input)
        {
            return
                Mapper.Map<List<EmployeeAttachementDto>>(
                    _employeeAttachementRepository.GetAllList(ea => ea.EmployeeId == input.EmployeeId));
        }

        #endregion

        #region EmployeeEmergencyContact

        public OutputBase CreateOrEditEmergencyContact(EmployeeEmergencyContactDto input)
        {
            _employeeEmergencyContactRepository.InsertOrUpdate(Mapper.Map<EmployeeEmergencyContact>(input));
            return new OutputBase {Message = "Contact saved", Success = true};
        }
        public OutputBase CreateEmployeeEmergencyContact(CreateEmployeeEmergencyContactInput input)
        {
            _employeeEmergencyContactRepository.Insert(Mapper.Map<EmployeeEmergencyContact>(input));
            return new OutputBase { Message = "Contact added", Success = true };
        }

        public OutputBase UpdateEmployeeEmergencyContact(EmployeeEmergencyContactDto input)
        {
            _employeeEmergencyContactRepository.Update(Mapper.Map<EmployeeEmergencyContact>(input));
            return new OutputBase { Message = "Cantact updated", Success = true };
        }

        public OutputBase DeleteEmployeeEmergencyContact(DeleteEmployeeEmergencyContactInput input)
        {
            _employeeEmergencyContactRepository.Delete(input.EmployeeEmergencyContactId);
            return new OutputBase { Message = "Contact Deleted", Success = true };
        }

        public EmployeeEmergencyContactDto GetEmployeeEmergencyContact(GetEmployeeEmergencyContactInput input)
        {
            return
                Mapper.Map<EmployeeEmergencyContactDto>(
                    _employeeEmergencyContactRepository.Get(input.EmployeeEmergencyContactId));
        }

        public ListResultOutput<EmployeeEmergencyContactDto> GetEmployeeEmergencyContacts(GetEmployeeEmergencyContactsInput input)
        {
            return new ListResultOutput<EmployeeEmergencyContactDto>(
                Mapper.Map<List<EmployeeEmergencyContactDto>>(
                    _employeeEmergencyContactRepository.GetAllList(e => e.EmployeeId == input.EmployeeId)));
        }

        #endregion

        #region Immigration

        public OutputBase CreateOrEditImmigration(ImmigrationDto immigration)
        {
            _immigrationRepository.InsertOrUpdate(Mapper.Map<Immigration>(immigration));
            return new OutputBase {Message = "Record Saved", Success = true};
        }

        public OutputBase DeleteImmigration(DeleteImmigrationInput input)
        {
            _immigrationRepository.Delete(input.ImmigrationId);
            return new OutputBase {Message = "Record deleted", Success = true};
        }

        public ImmigrationDto GetImmigration(GetImmigrationInput input)
        {
            return Mapper.Map<ImmigrationDto>(_immigrationRepository.FirstOrDefault(i => i.Id == input.ImmigrationId));
        }

        public ListResultOutput<ImmigrationDto> GetImmigrations(GetImmigrationsInput input)
        {
            return
                new ListResultOutput<ImmigrationDto>(Mapper.Map<List<ImmigrationDto>>(
                    _immigrationRepository.GetAllList(i => i.EmployeeId == input.EmployeeId)));
        }
        #endregion

        #region Supervisors

        public OutputBase AddSupervisor(SupervisorDto supervisor)
        {
            if (
                _supervisorRepository.Query(
                    q => q.Any(s => s.EmployeeId == supervisor.EmployeeId && s.SupervisorId == supervisor.SupervisorId)))
            {
                return new OutputBase
                {
                    Message = "The selected Supervisor hase already been added for this Employee",
                    Success = false
                };
            }
            _supervisorRepository.Insert(Mapper.Map<Supervisor>(supervisor));
            return new OutputBase {Message = "Save successfully", Success = true};
        }

        public OutputBase DeleteSupervisor(DeleteSupervisorInput input)
        {
            _supervisorRepository.Delete(input.SupervisorId);
            return new OutputBase {Message = "Record Deleted"};
        }

        public SupervisorDto GetSupervisor(GetSupervisorInput input)
        {
            return Mapper.Map<SupervisorDto>(_supervisorRepository.Get(input.SupervisorId));
        }

        public ListResultOutput<SupervisorDto> GetSupervisors(GetSupervisorsInput input)
        {
            return new ListResultOutput<SupervisorDto>(
                Mapper.Map<List<SupervisorDto>>(_supervisorRepository.GetAllList(s => s.EmployeeId == input.EmployeeId)));
        }

        public ListResultOutput<SupervisorDto> GetSubordinates(GetSupervisorsInput input)
        {
            return new ListResultOutput<SupervisorDto>(
                Mapper.Map<List<SupervisorDto>>(_supervisorRepository.GetAllList(s => s.SupervisorId == input.EmployeeId)));
        }


        public ListResultOutput<SupervisorDo> GetSubOrdinates(GetSupervisorsInput input)
        {
            return new ListResultOutput<SupervisorDo>(_supervisorRepository.GetSupervisorDos(input.EmployeeId).ToList());
        }
        public ListResultOutput<SupervisorDo> GetSupervisorDos(GetSupervisorsInput input)
        {
            return new ListResultOutput<SupervisorDo>(_supervisorRepository.GetSupervisorDos(input.EmployeeId).ToList());
        }
        #endregion

        #region EmployeeMembership

        public OutputBase SaveEmployeeMembership(SaveEmployeeMembershipInput input)
        {
            _membershipRepository.InsertOrUpdate(Mapper.Map<EmployeeMembership>(input.EmployeeMembership));
            return new OutputBase {Message = "Information save", Success = true};
        }

        public EmployeeMembershipDto GetEmployeeMembership(GetEmployeeMembershipInput input)
        {
            return Mapper.Map<EmployeeMembershipDto>(_membershipRepository.Get(input.EmployeeMembershipId));
        }

        public ListResultOutput<EmployeeMembershipDto> GetEmployeeMemberships(GetEmployeeMembershipsInput input)
        {
            return
                new ListResultOutput<EmployeeMembershipDto>(
                    Mapper.Map<List<EmployeeMembershipDto>>(
                        _membershipRepository.GetAllList(m => m.EmployeeId == input.EmployeeId)));
        } 

        public OutputBase DeleteEmployeeMemebership(DeleteEmployeeMembershipInput input)
        {
            _membershipRepository.Delete(input.EmployeeMembershipId);
            return new OutputBase {Message = "Membership deleted", Success = true};
        }

        #endregion
    }
}