using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Timing;
using Abp.Web.Models;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.Organisation;
using SoftBreeze.BlueHrm.PersonalInformation;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Contacts;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Dependants;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Educations;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeEmergencyContacts;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.EmployeeMemberships;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Employees;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Immigrations;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.JobInfo;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Salaries;
using SoftBreeze.BlueHrm.PersonalInformation.Dto.Supervisor;
using SoftBreeze.BlueHrm.Storage;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.Web.Areas.Pim.Models;
using SoftBreeze.BlueHrm.Web.Controllers;

namespace SoftBreeze.BlueHrm.Web.Areas.Pim.Controllers
{
    public class EmployeeListController : BlueHrmControllerBase
    {
        public const string BasicSection = "basic";
        public const string Contacts = "contacts";
        public const string EmergencyContacts = "emergencycontacts";
        public const string Dependants = "dependants";
        public const string Immigration = "immigration";
        public const string Job = "job";
        public const string Salary = "salary";
        public const string Supervisors = "supervisors";
        public const string Qualifications = "qualifications";
        public const string Memberships = "memberships";

        private readonly IEmployeeService _employeeService;
        private readonly IJobConfigurationService _jobConfigurationService;
        private readonly IOrganisationService _organisationService;
        private readonly IConfigurationService _configurationService;
        private readonly IQualificationService _qualificationService;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userService;

        private EmployeeDto _employee;

        public EmployeeListController(IEmployeeService userAppService, IBinaryObjectManager binaryObjectManager,
            UserManager userManager, IUserAppService userService, IJobConfigurationService jobConfigurationService,
            IOrganisationService organisationService, IConfigurationService configurationService, IQualificationService qualificationService)
        {
            _employeeService = userAppService;
            _jobConfigurationService = jobConfigurationService;
            _organisationService = organisationService;
            _qualificationService = qualificationService;
            _binaryObjectManager = binaryObjectManager;
            _userManager = userManager;
            _userService = userService;
            _configurationService = configurationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region detail
        public ActionResult Detail(string id, string section = BasicSection)
        {
            _employee = _employeeService.GetEmployeeByNumber(new GetEmployeeByNumberInput { Number = id });
            ViewBag.Employee = _employee;

            switch (section)
            {
                case BasicSection:
                    return BasicSectionView(id);
                case Contacts:
                    return ContactView(id);
                case EmergencyContacts:
                    return EmergendyContactView(id);
                case Dependants:
                    return DependatsView(id);
                case Immigration:
                    return ImmigrationView(id);
                case Job:
                    return JobView(id);
                case Salary:
                    return SalaryView(id);
                case Supervisors:
                    return SupervisorsView(id);
                case Qualifications:
                    return QualificationView(id);
                case Memberships:
                    return MembershipsView(id);



                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Search(string term)
        {
            var employees = _employeeService.Search(term);
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        //BasicSectionView
        protected ActionResult BasicSectionView(string employeeNumber)
        {
            var employee = _employeeService.GetEmployeeByNumber(new GetEmployeeByNumberInput { Number = employeeNumber });
            return View("EmployeeDetail/Basic/Basic", employee);
        }
         

        //contact
        protected ActionResult ContactView(string employerNumber)
        {
            var contact = _employeeService.GetContact(new GetContactInput {ContactId = _employee.Id});
            return View("EmployeeDetail/Contact/Contact", contact??new ContactDto());
        }
        
        //EmergencyContacts
        protected ActionResult EmergendyContactView(string employeeId)
        {
            return View("EmployeeDetail/EmergencyContacts/EmergencyContacts"); 
        }
        
        public async Task<PartialViewResult> CreateOrEditEmergencyContactModal(int? id, int employeeId)
        {
            var output = new EmployeeEmergencyContactDto();
            if (id != null)
            {
                output =
                    _employeeService.GetEmployeeEmergencyContact(new GetEmployeeEmergencyContactInput
                    {
                        EmployeeEmergencyContactId = id.Value
                    });
            }
            var viewModel = new CreateOrEditEmergencyContactModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;

            return PartialView("EmployeeDetail/EmergencyContacts/_CreateOrEditEmergencyContactModal", viewModel);
        }



        //DependatsView
        protected ActionResult DependatsView(string employeeId)
        {
            return View("EmployeeDetail/Dependants/Dependants");
        }

        public async Task<PartialViewResult> CreateOrEditDependantModal(int? id, int employeeId)
        {
            var output = new DependantDto {DateOfBirth = Clock.Now };
            if (id != null)
            {
                output =
                    _employeeService.GetDependant(new GetDependantInput {DependantId = id.Value});
            }
            var viewModel = new CreateOrEditDependantModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;

            return PartialView("EmployeeDetail/Dependants/_CreateOrEditDependantModal", viewModel);
        }


        //ImmigrationView
        protected ActionResult ImmigrationView(string employeeId)
        {
            return View("EmployeeDetail/Immigration/Immigration");
        }

        public async Task<PartialViewResult> CreateOrEditImmigrationModal(int? id, int employeeId)
        {
            var output = new ImmigrationDto ();
            if (id != null)
            {
                output =
                    _employeeService.GetImmigration(new GetImmigrationInput { ImmigrationId = id.Value });
            }
            var viewModel = new CreateOrEditImmigrationModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;

            return PartialView("EmployeeDetail/Immigration/_CreateOrEditImmigrationModal", viewModel);
        }


        //JobView
        protected ActionResult JobView(string employeeId)
        {
            var jobInfo = _employeeService.GetJobInformation(new GetJobInformationInput { EmployeeId = _employee.Id });
            jobInfo = jobInfo ?? new JobInformationDto {Id = _employee.Id, JoinDate = DateTime.UtcNow};

            ViewBag.JobId = new SelectList(_jobConfigurationService.GetJobs().Items, "Id", "Title", jobInfo.JobId);
            ViewBag.StatusId = new SelectList(_jobConfigurationService.GetEmploymentStatuses().Items, "Id", "Name", jobInfo.StatusId);
            ViewBag.JobCategoryId = new SelectList(_jobConfigurationService.GetJobCategories().Items, "Id", "Name", jobInfo.JobCategoryId);
            ViewBag.LocationId = new SelectList(_organisationService.GetLocations().Items, "Id", "Name", jobInfo.LocationId);
            ViewBag.UnitId = new SelectList(_organisationService.GetUnits().Items, "Id", "Name", jobInfo.UnitId);

            return View("EmployeeDetail/Job/Job", jobInfo);
        }


        //SalaryView
        protected ActionResult SalaryView(string employeeId)
        {
            return View("EmployeeDetail/Salary/Salary");
        }
        public async Task<PartialViewResult> CreateOrEditSalaryCompunentModal(int? id, int employeeId)
        {
            var output = new SalaryDto();
            if (id != null)
            {
                output = _employeeService.GetSalary(new GetSalaryInput {SalaryId = id.Value});
            }
            var viewModel = new CreateOrEditSalaryModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;

            ViewBag.SalaryComponentId = new SelectList(_configurationService.GetSalaryCompunents().Items, "Id", "Name",
                output.SalaryComponentId);
            ViewBag.PayGradeId = new SelectList(_jobConfigurationService.GetPayGrades().Items, "Id", "Name", output.PayGradeId);
            ViewBag.PayFrequencyId = new SelectList(_configurationService.GetPayFrequencies().Items, "Id", "Name",
                output.PayFrequencyId);
            ViewBag.CurrencyId = new SelectList(_configurationService.GetCurrencies().Items, "Id", "Name",
                output.CurrencyId);
            return PartialView("EmployeeDetail/Salary/_CreateOrEditSalaryModal", viewModel);
        }

        //SupervisorsView
        protected ActionResult SupervisorsView(string employeeId)
        {
            return View("EmployeeDetail/Supervisors/Supervisors");
        }

        public async Task<PartialViewResult> CreateOrEditSupervisorModal(int? id, int employeeId)
        {
            var output = new SupervisorDto();
            if (id != null)
            {
                output = _employeeService.GetSupervisor(new GetSupervisorInput {SupervisorId = id.Value});
            }
            var viewModel = new CreateOrEditSupervisorModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;
            ViewBag.ReportMethods = new SelectList(new List<EmployeeReportMethod>
            {
                EmployeeReportMethod.Direct,
                EmployeeReportMethod.Inderect,
                EmployeeReportMethod.Others
            });
            ViewBag.Employees =
                new SelectList(_employeeService.GetEmployees().Where(e => e.Id != employeeId).OrderBy(e => e.Fullname),
                    "Id", "Fullname", output.EmployeeId);

            return PartialView("EmployeeDetail/Supervisors/_CreateOrEditSupervisorModal", viewModel);
        }

        protected ActionResult QualificationView(string employeeId)
        {
            return View("EmployeeDetail/Qualification/Qualification");
        }

        public async Task<PartialViewResult> CreateOrEditQualificationModal(int? id, int employeeId)
        {
            var output = new EducationDto();
            if (id != null)
            {
                output = _employeeService.GetEducation(new GetEducationInput {EducationId = id.Value});
            }
            var viewModel = new CreateOrEditQualificationModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;

            var yearList = new List<int>();
            for(var y = Clock.Now.Year; y >= 1900; y--)
                yearList.Add(y);

            ViewBag.Years = new SelectList(yearList, output.Year);
            ViewBag.EducationalLevels = new SelectList(_qualificationService.GetEducationLevels().Items, "Id", "Name",
                output.LevelId);

            return PartialView("EmployeeDetail/Qualification/_CreateOrEditQualificationModal", viewModel);
        }


        protected ActionResult MembershipsView(string employeeId)
        {
            return View("EmployeeDetail/Memberships/Memberships");
        }

        public async Task<PartialViewResult> CreateOrEditMembershipsModal(int? id, int employeeId)
        {
            var output = new EmployeeMembershipDto();
            if (id != null)
            {
                output = _employeeService.GetEmployeeMembership(new GetEmployeeMembershipInput {EmployeeMembershipId = id.Value});
            }
            var viewModel = new CreateOrEditMembershipModel(output, id == null || id == 0);
            ViewBag.EmployeeId = employeeId;
            

            return PartialView("EmployeeDetail/Qualification/_CreateOrEditQualificationModal", viewModel);
        }

        #endregion

























        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = new EmployeeDto { Contact = new ContactDto() };

            if (id != null)
            {
                output = _employeeService.GetEmployee(new GetEmployeeInput { EmployeeId = id.Value });
            }
            var viewModel = new CreateOrEditEmployeeModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
        
    }
}