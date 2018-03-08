using AutoMapper;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Authorization.Users.Dto;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.EmploymentStatuses;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobCategories;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.Jobs;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.JobTerminationReasons;
using SoftBreeze.BlueHrm.JobConfiguration.Dto.PayGrades;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.LeaveModule.Dto;
using SoftBreeze.BlueHrm.Organisation.Dto.Locations;
using SoftBreeze.BlueHrm.Organisation.Dto.Units;
using SoftBreeze.BlueHrm.Organization;
using SoftBreeze.BlueHrm.Performance;
using SoftBreeze.BlueHrm.PersonalInformation;
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
using SoftBreeze.BlueHrm.Proformances.Dto;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;
using SoftBreeze.BlueHrm.SystemConfiguration.Payrol;
using SoftBreeze.BlueHrm.TimeModule;
using SoftBreeze.BlueHrm.TimeModule.Dto;

namespace SoftBreeze.BlueHrm
{
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        public static void CreateMappings()
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal();

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal()
        {
            Mapper.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());

            Mapper.CreateMap<EmploymentStatus, EmploymentStatusDto>().ReverseMap();

            Mapper.CreateMap<Job, JobDto>().ReverseMap();
            Mapper.CreateMap<JobDto, CreateJobInput>().ReverseMap();
            Mapper.CreateMap<CreateJobInput, Job>().ReverseMap();

            Mapper.CreateMap<JobCategory, JobCategoryDto>().ReverseMap();
            Mapper.CreateMap<CreateJobCategoryInput, JobCategory>();

            Mapper.CreateMap<JobTerminationReason, JobTerminationReasonDto>().ReverseMap();
            Mapper.CreateMap<CreateJobTerminationReasonInput, JobTerminationReason>();

            Mapper.CreateMap<PayGrade, PayGradeDto>().ReverseMap();
            Mapper.CreateMap<CreatePayGradeInput, PayGrade>();

            Mapper.CreateMap<LocationDto, Location>().ReverseMap();
            Mapper.CreateMap<CreateLocationInput, Location>();

            Mapper.CreateMap<Unit, UnitDto>().ReverseMap();
            Mapper.CreateMap<CreateUnitInput, Unit>();
            Mapper.CreateMap<UpdateUnitInput, Unit>();

            //qualification
            Mapper.CreateMap<Skill, SkillDto>().ReverseMap();
            Mapper.CreateMap<EducationLevelDto, EducationalLevel>().ReverseMap();
            Mapper.CreateMap<LicenseType, LicenseTypeDto>().ReverseMap();

            //PIM
            Mapper.CreateMap<Contact, ContactDto>().ReverseMap();
            Mapper.CreateMap<UpdateContactInput, Contact>();
            Mapper.CreateMap<CreateContactInput, Contact>();

            Mapper.CreateMap<Dependant, DependantDto>().ReverseMap();
            Mapper.CreateMap<CreateDependantInput, Dependant>();
            Mapper.CreateMap<UpdateDependantInput, Dependant>();

            Mapper.CreateMap<Employee, EmployeeDto>().ReverseMap();
            Mapper.CreateMap<CreateEmployeeInput, Employee>();
            Mapper.CreateMap<UpdateEmployeeInput, Employee>();

            Mapper.CreateMap<EmployeeAttachementDto, EmployeeAttachement>().ReverseMap();
            Mapper.CreateMap<CreateEmployeeAttachementInput, EmployeeAttachement>();

            Mapper.CreateMap<EmployeeEmergencyContact, EmployeeEmergencyContactDto>().ReverseMap();
            Mapper.CreateMap<CreateEmployeeEmergencyContactInput, EmployeeEmergencyContact>();
            Mapper.CreateMap<UpdateEmployeeEmergencyContactInput, EmployeeEmergencyContact>();

            Mapper.CreateMap<Immigration, ImmigrationDto>().ReverseMap();
            Mapper.CreateMap<JobInformationDto, JobInformation>().ReverseMap();

            Mapper.CreateMap<CountryDto, Country>().ReverseMap();
            Mapper.CreateMap<Currency, CurrencyDto>().ReverseMap();

            Mapper.CreateMap<SalaryPayFrequency, SalaryPayFrequencyDto>().ReverseMap();
            Mapper.CreateMap<SalaryComponent, SalaryCompunentDto>().ReverseMap();

            Mapper.CreateMap<Salary, SalaryDto>().ReverseMap();
            Mapper.CreateMap<Supervisor, SupervisorDto>().ReverseMap();

            Mapper.CreateMap<Education, EducationDto>().ReverseMap();
            Mapper.CreateMap<EmployeeMembership, EmployeeMembershipDto>().ReverseMap();

            Mapper.CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            Mapper.CreateMap<LeavePeriodDto, LeavePeriod>().ReverseMap();

            Mapper.CreateMap<LeaveEntitlement, LeaveEntitlementDto>().ReverseMap();
            Mapper.CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();

            Mapper.CreateMap<Attendance, AttendanceDto>().ReverseMap();

            //Performance
            Mapper.CreateMap<PerformacneIndicatorDto, PerformanceIndicator>().ReverseMap();
            Mapper.CreateMap<PerformanceEvaluationPeriodDto, PerformanceEvaluationPeriod>().ReverseMap();

            Mapper.CreateMap<StaffPerformanceDto, StaffPerformance>().ReverseMap();
            Mapper.CreateMap<KeyResultArea, KeyResultAreaDto>().ReverseMap();

        }
    }
}