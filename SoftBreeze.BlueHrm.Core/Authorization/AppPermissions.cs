namespace SoftBreeze.BlueHrm.Authorization
{
    /// <summary>
    /// Defines string constants for application's permission names.
    /// <see cref="AppAuthorizationProvider"/> for permission definitions.
    /// </summary>
    public static class AppPermissions
    {
        //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

        public const string Pages = "Pages";
        
        public const string Pages_Administration = "Pages.Administration";

        public const string Pages_Administration_Roles = "Pages.Administration.Roles";
        public const string Pages_Administration_Roles_Create = "Pages.Administration.Roles.Create";
        public const string Pages_Administration_Roles_Edit = "Pages.Administration.Roles.Edit";
        public const string Pages_Administration_Roles_Delete = "Pages.Administration.Roles.Delete";

        public const string Pages_Administration_Users = "Pages.Administration.Users";
        public const string Pages_Administration_Users_Create = "Pages.Administration.Users.Create";
        public const string Pages_Administration_Users_Edit = "Pages.Administration.Users.Edit";
        public const string Pages_Administration_Users_Delete = "Pages.Administration.Users.Delete";
        public const string Pages_Administration_Users_ChangePermissions = "Pages.Administration.Users.ChangePermissions";

        public const string Pages_Administration_Languages = "Pages.Administration.Languages";
        public const string Pages_Administration_Languages_Create = "Pages.Administration.Languages.Create";
        public const string Pages_Administration_Languages_Edit = "Pages.Administration.Languages.Edit";
        public const string Pages_Administration_Languages_Delete = "Pages.Administration.Languages.Delete";
        public const string Pages_Administration_Languages_ChangeTexts = "Pages.Administration.Languages.ChangeTexts";

        public const string Pages_Administration_AuditLogs = "Pages.Administration.AuditLogs";

        //Job Configuration
        public const string Pages_Administration_JobConfiguration = "Pages.Administration.JobConfiguration";

        public const string Pages_Administration_JobConfiguration_JobTitle = "Pages.Administration.JobConfiguration.JobTitle";
        public const string Pages_Administration_JobConfiguration_JobTitle_Create = "Pages.Administration.JobConfiguration.JobTitle.Create";
        public const string Pages_Administration_JobConfiguration_JobTitle_Edit = "Pages.Administration.JobConfiguration.JobTitle.Edit";
        public const string Pages_Administration_JobConfiguration_JobTitle_Delete = "Pages.Administration.JobConfiguration.JobTitle.Delete";

        public const string Pages_Administration_JobConfiguration_PayGrade = "Pages.Administration.JobConfiguration.PayGrade";
        public const string Pages_Administration_JobConfiguration_PayGrade_Create = "Pages.Administration.JobConfiguration.PayGrade.Create";
        public const string Pages_Administration_JobConfiguration_PayGrade_Edit = "Pages.Administration.JobConfiguration.PayGrade.Edit";
        public const string Pages_Administration_JobConfiguration_PayGrade_Delete = "Pages.Administration.JobConfiguration.PayGrade.Delete";

        public const string Pages_Administration_JobConfiguration_EmployeeStatus = "Pages.Administration.JobConfiguration.EmployeeStatus";
        public const string Pages_Administration_JobConfiguration_EmployeeStatus_Create = "Pages.Administration.JobConfiguration.EmployeeStatus.Create";
        public const string Pages_Administration_JobConfiguration_EmployeeStatus_Edit = "Pages.Administration.JobConfiguration.EmployeeStatus.Edit";
        public const string Pages_Administration_JobConfiguration_EmployeeStatus_Delete = "Pages.Administration.JobConfiguration.EmployeeStatus.Delete";

        public const string Pages_Administration_JobConfiguration_JobCategories = "Pages.Administration.JobConfiguration.JobCategories";
        public const string Pages_Administration_JobConfiguration_JobCategories_Create = "Pages.Administration.JobConfiguration.JobCategories.Create";
        public const string Pages_Administration_JobConfiguration_JobCategories_Edit = "Pages.Administration.JobConfiguration.JobCategories.Edit";
        public const string Pages_Administration_JobConfiguration_JobCategories_Delete = "Pages.Administration.JobConfiguration.JobCategories.Delete";

        public const string Pages_Administration_JobConfiguration_JobTerminationReasons = "Pages.Administration.JobConfiguration.JobTerminationReasons";
        public const string Pages_Administration_JobConfiguration_JobTerminationReasons_Create = "Pages.Administration.JobConfiguration.JobTerminationReasons.Create";
        public const string Pages_Administration_JobConfiguration_JobTerminationReasons_Edit = "Pages.Administration.JobConfiguration.JobTerminationReasons.Edit";
        public const string Pages_Administration_JobConfiguration_JobTerminationReasons_Delete = "Pages.Administration.JobConfiguration.JobTerminationReasons.Delete";

        //Organisation
        public const string Pages_Administration_Organisation = "Pages.Administration.Organisation";

        public const string Pages_Administration_Organisation_GeneralInformation = "Pages.Administration.Organisation.GeneralInformation";
        public const string Pages_Administration_Organisation_GeneralInformation_Update = "Pages.Administration.Organisation.GeneralInformation.Update";

        public const string Pages_Administration_Organisation_Locations = "Pages.Administration.Organisation.Locations";
        public const string Pages_Administration_Organisation_Locations_Create = "Pages.Administration.Organisation.Locations.Create";
        public const string Pages_Administration_Organisation_Locations_Edit = "Pages.Administration.Organisation.Locations.Edit";
        public const string Pages_Administration_Organisation_Locations_Delete = "Pages.Administration.Organisation.Locations.Delete";

        public const string Pages_Administration_Organisation_Units = "Pages.Administration.Organisation.Units";
        public const string Pages_Administration_Organisation_Units_Create = "Pages.Administration.Organisation.Units.Create";
        public const string Pages_Administration_Organisation_Units_Edit = "Pages.Administration.Organisation.Units.Edit";
        public const string Pages_Administration_Organisation_Units_Delete = "Pages.Administration.Organisation.Units.Delete";


        //Qualification
        public const string Pages_Administration_Qualification = "Pages.Administration.Qualification";

        public const string Pages_Administration_Qualification_Skills = "Pages.Administration.Qualification.Skills";
        public const string Pages_Administration_Qualification_Skill_Create = "Pages.Administration.Qualification.Skill.Create";
        public const string Pages_Administration_Qualification_Skill_Edit = "Pages.Administration.Qualification.Skill.Edit";
        public const string Pages_Administration_Qualification_Skill_Delete = "Pages.Administration.Qualification.Skill.Delete";

        public const string Pages_Administration_Qualification_EducationalLevel = "Pages.Administration.Qualification.EducationalLevels";
        public const string Pages_Administration_Qualification_EducationalLevel_Create = "Pages.Administration.Qualification.EducationalLevel.Create";
        public const string Pages_Administration_Qualification_EducationalLevel_Edit = "Pages.Administration.Qualification.EducationalLevel.Edit";
        public const string Pages_Administration_Qualification_EducationalLevel_Delete = "Pages.Administration.Qualification.EducationalLevel.Delete";

        public const string Pages_Administration_Qualification_Licenses = "Pages.Administration.Qualification.Licenses";
        public const string Pages_Administration_Qualification_License_Create = "Pages.Administration.Qualification.License.Create";
        public const string Pages_Administration_Qualification_License_Edit = "Pages.Administration.Qualification.License.Edit";
        public const string Pages_Administration_Qualification_License_Delete = "Pages.Administration.Qualification.License.Delete";




        public const string Pages_Pim = "Pages.Pim";

        public const string Pages_Pim_Eployees = "Pages.Pim.Employees";
        public const string Pages_Pim_Eployees_List = "Pages.Pim.Employees.List";
        public const string Pages_Pim_Eployee_Create = "Pages.Pim.Employee.Create";
        public const string Pages_Pim_Eployee_Edit = "Pages.Pim.Employee.Edit";
        public const string Pages_Pim_Eployee_Delete = "Pages.Pim.Employee.Delete";

        public const string Pages_Pim_Report = "Pages.Pim.Report";



        //Leave
        public const string Pages_Leave = "Pages.Leave";
        public const string Pages_Leaves_Create = "Pages.Leaves.Create";
        public const string Pages_Leaves_Edit = "Pages.Leaves.Edit";
        public const string Pages_Leaves_Delete = "Pages.Leaves.Delete";

        public const string Pages_Leave_LeaveTypes = "Pages.Leave.LeaveTypes";
        public const string Pages_Leave_LeaveTypes_Create = "Pages.Leave.LeaveTypes.Create";
        public const string Pages_Leave_LeaveTypes_Edit = "Pages.Leave.LeaveTypes.Edit";
        public const string Pages_Leave_LeaveTypes_Delete = "Pages.Leave.LeaveTypes.Delete";

        public const string Pages_Leave_LeaveEntitlements = "Pages.Leave.LeaveEntitlements";
        public const string Pages_Leave_LeaveEntitlements_Create = "Pages.Leave.LeaveEntitlements.Create";
        public const string Pages_Leave_LeaveEntitlements_Edit = "Pages.Leave.LeaveEntitlements.Edit";
        public const string Pages_Leave_LeaveEntitlements_Delete = "Pages.Leave.LeaveEntitlements.Delete";

        public const string Pages_Leave_LeaveRequest = "Pages.Leave.LeaveRequest";
        public const string Pages_Leave_LeaveRequest_MakeRequest = "Pages.Leave.LeaveRequest.MakeRequest";
        public const string Pages_Leave_LeaveRequest_DeleteAny = "Pages.Leave.LeaveRequest.DeleteAny";
        public const string Pages_Leave_LeaveRequest_ViewAll = "Pages.Leave.LeaveRequest.ViewAll";
        public const string Pages_Leave_LeaveRequest_Approve = "Pages.Leave.LeaveRequest.Approve";
        public const string Pages_Leave_LeaveRequest_Reject = "Pages.Leave.LeaveRequest.Reject";

        //Timing
        public const string Pages_Timing = "Pages.Timing";
        public const string Pages_Timing_Attendances = "Pages.Timing.Attendances";
        public const string Pages_Timing_Attendances_Report = "Pages.Timing.Attendances.Report";
        public const string Pages_Timing_Attendances_ViewAll = "Pages.Timing.Attendances.ViewAll";
        public const string Pages_Timing_Attendance_PunchIn = "Pages.Timing.Attendance.PunchIn";
        public const string Pages_Timing_Attendance_PunchOut = "Pages.Timing.Attendance.PunchOut";
        public const string Pages_Timing_Attendance_Create = "Pages.Timing.Attendance.Create";
        public const string Pages_Timing_Attendance_Edit = "Pages.Timing.Attendance.Edit";
        public const string Pages_Timing_Attendance_Delete = "Pages.Timing.Attendance.Delete";

        //Performance
        public const string Pages_Performance = "Pages.Performance";

        public const string Pages_Performance_KeyResultAreas = "Pages.Performance.KeyResultAreas";
        public const string Pages_Performance_KeyResultAreas_Create = "Pages.Performance.KeyResultAreas.Create";
        public const string Pages_Performance_KeyResultAreas_Edit = "Pages.Performance.KeyResultAreas.Edit";
        public const string Pages_Performance_KeyResultAreas_Delete = "Pages.Performance.KeyResultAreas.Delete";

        public const string Pages_Performance_Record = "Pages.Performance.Record";
        public const string Pages_Performance_Record_Create = "Pages.Performance.Record.Create";
        public const string Pages_Performance_Record_Edit = "Pages.Performance.Record.Edit";
        public const string Pages_Performance_Record_Delete = "Pages.Performance.Record.Delete";

        public const string Pages_Performance_Report = "Pages.Performance.Report";
        public const string Pages_Performance_Report_MyPerformance = "Pages.Performance.Report.MyPerformance";
        public const string Pages_Performance_Report_ViewAll = "Pages.Performance.Report.ViewAll";

        //TENANT-SPECIFIC PERMISSIONS Entitlements

        public const string Pages_Tenant_Dashboard = "Pages.Tenant.Dashboard";
        public const string Pages_Tenant_PhoneBook = "Pages.Tenant.PhoneBook";
        public const string Pages_Tenant_PhoneBook_CreatePerson = "Pages.Tenant.BlueHrm.Create";
        public const string Pages_Tenant_PhoneBook_DeletePerson = "Pages.Tenant.BlueHrm.Delete";

        public const string Pages_Administration_Tenant_Settings = "Pages.Administration.Tenant.Settings";
        
        //HOST-SPECIFIC PERMISSIONS

        public const string Pages_Editions = "Pages.Editions";
        public const string Pages_Editions_Create = "Pages.Editions.Create";
        public const string Pages_Editions_Edit = "Pages.Editions.Edit";
        public const string Pages_Editions_Delete = "Pages.Editions.Delete";

        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Tenants_Create = "Pages.Tenants.Create";
        public const string Pages_Tenants_Edit = "Pages.Tenants.Edit";
        public const string Pages_Tenants_ChangeFeatures = "Pages.Tenants.ChangeFeatures";
        public const string Pages_Tenants_Delete = "Pages.Tenants.Delete";

        public const string Pages_Administration_Host_Settings = "Pages.Administration.Host.Settings";
    }
}