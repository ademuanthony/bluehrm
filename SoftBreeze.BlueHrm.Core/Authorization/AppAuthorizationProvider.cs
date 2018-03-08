using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace SoftBreeze.BlueHrm.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
            
            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));
            
            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));

            //job config
            var jobConfiguation =
                administration.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration,
                    L("JobConfig"));

            var jobTitles = jobConfiguation.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTitle,
                L("JobTitles"));
            jobTitles.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTitle_Create,
                L("CreateNewJobTitle"));
            jobTitles.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTitle_Edit,
                L("EditJobTitle"));
            jobTitles.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTitle_Delete,
                L("DeleteJobTitle"));

            var payGrades = jobConfiguation.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_PayGrade,
                L("PayGrades"));
            payGrades.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_PayGrade_Create,
                L("CreateNewPayGrade"));
            payGrades.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_PayGrade_Edit,
                L("EditPayGrade"));
            payGrades.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_PayGrade_Delete,
                L("DeletePayGrade"));

            var employeeStatus = jobConfiguation.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_EmployeeStatus,
                L("EmployeeStatuses"));
            employeeStatus.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_EmployeeStatus_Create,
                L("CreateNewEmployeeStatus"));
            employeeStatus.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_EmployeeStatus_Edit,
                L("EditEmployeeStatus"));
            employeeStatus.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_EmployeeStatus_Delete,
                L("DeleteEmployeeStatus"));


            var jobCategory = jobConfiguation.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobCategories,
                L("JobCategories"));
            jobCategory.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobCategories_Create,
                L("CreateNewJobCategory"));
            jobCategory.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobCategories_Edit,
                L("EditJobCategory"));
            jobCategory.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobCategories_Delete,
                L("DeleteJobCategory"));


            var jobTerminationReason = jobConfiguation.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTerminationReasons,
                L("JobTerminationReasons"));
            jobTerminationReason.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTerminationReasons_Create,
                L("CreateNewJobTerminationReason"));
            jobTerminationReason.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTerminationReasons_Edit,
                L("EditJobTerminationReason"));
            jobTerminationReason.CreateChildPermission(AppPermissions.Pages_Administration_JobConfiguration_JobTerminationReasons_Delete,
                L("DeleteJobTerminationReason"));


            //Organisation
            var organisation =
                administration.CreateChildPermission(AppPermissions.Pages_Administration_Organisation,
                    L("Organisation"));

            var generalInformation = organisation.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_GeneralInformation,
                L("GeneralInformation"));
            generalInformation.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_GeneralInformation_Update,
                L("UpdateGeneralInformation"));

            var locations = organisation.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Locations,
                L("Locations"));
            locations.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Locations_Create,
                L("CreateLocation"));
            locations.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Locations_Edit,
                L("EditLocation"));
            locations.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Locations_Delete,
                L("DeleteLocation"));

            var units = organisation.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Units,
                L("Units"));
            units.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Units_Create,
                L("CreateLocation"));
            units.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Units_Edit,
                L("EditLocation"));
            units.CreateChildPermission(AppPermissions.Pages_Administration_Organisation_Units_Delete,
                L("DeleteLocation"));

            //qaulification
            var qaulification = administration.CreateChildPermission(AppPermissions.Pages_Administration_Qualification, L("Qaulification"));

            var skill = qaulification.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_Skills, L("Skills"));
            skill.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_Skill_Create, L("CreateSkill"));
            skill.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_Skill_Edit, L("EditSkill"));
            skill.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_Skill_Delete, L("DeleteSkill"));

            var educationalLevel = qaulification.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_EducationalLevel, L("EducationalLevels"));
            educationalLevel.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_EducationalLevel_Create, L("CreateEducationalLevel"));
            educationalLevel.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_EducationalLevel_Edit, L("EditEducationalLevel"));
            educationalLevel.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_EducationalLevel_Delete, L("DeleteEducationalLevel"));


            var license = qaulification.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_Licenses, L("Licenses"));
            license.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_License_Create, L("CreateLicense"));
            license.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_License_Edit, L("EditLicense"));
            license.CreateChildPermission(AppPermissions.Pages_Administration_Qualification_License_Delete, L("DeleteLicense"));





            //language  Locations
            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));


            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            //Pim
            var pim = pages.CreateChildPermission(AppPermissions.Pages_Pim, L("Pim"));

            var employee = pim.CreateChildPermission(AppPermissions.Pages_Pim_Eployees, L("Employees"));
            employee.CreateChildPermission(AppPermissions.Pages_Pim_Eployees_List, L("EmployeesList"));
            employee.CreateChildPermission(AppPermissions.Pages_Pim_Eployee_Create, L("CreateEmployee"));
            employee.CreateChildPermission(AppPermissions.Pages_Pim_Eployee_Edit, L("EditEmployee"));
            employee.CreateChildPermission(AppPermissions.Pages_Pim_Eployee_Delete, L("DeleteEmployee"));

            pim.CreateChildPermission(AppPermissions.Pages_Pim_Report, L("Report"));


            //LEAVE
            var leave = pages.CreateChildPermission(AppPermissions.Pages_Leave, L("Leave"));
            leave.CreateChildPermission(AppPermissions.Pages_Leaves_Create, L("AssignLeave"));
            leave.CreateChildPermission(AppPermissions.Pages_Leaves_Edit, L("EditLeave"));
            leave.CreateChildPermission(AppPermissions.Pages_Leaves_Delete, L("DeleteLeave"));

            var leaveTypes = leave.CreateChildPermission(AppPermissions.Pages_Leave_LeaveTypes, L("LeaveTypes"));
            leaveTypes.CreateChildPermission(AppPermissions.Pages_Leave_LeaveTypes_Create, L("CreateLeaveType"));
            leaveTypes.CreateChildPermission(AppPermissions.Pages_Leave_LeaveTypes_Edit, L("EditLeaveType"));
            leaveTypes.CreateChildPermission(AppPermissions.Pages_Leave_LeaveTypes_Delete, L("DeleteLeaveType"));

            var leaveEntitlements = leave.CreateChildPermission(AppPermissions.Pages_Leave_LeaveEntitlements, L("LeaveEntitlements"));
            leaveEntitlements.CreateChildPermission(AppPermissions.Pages_Leave_LeaveEntitlements_Create, L("CreateEntitlement"));
            leaveEntitlements.CreateChildPermission(AppPermissions.Pages_Leave_LeaveEntitlements_Edit, L("EditEntitlement"));
            leaveEntitlements.CreateChildPermission(AppPermissions.Pages_Leave_LeaveEntitlements_Delete, L("DeleteEntitlement"));

            var leaveRequest = leave.CreateChildPermission(AppPermissions.Pages_Leave_LeaveRequest, L("LeaveRequest"));
            leaveRequest.CreateChildPermission(AppPermissions.Pages_Leave_LeaveRequest_MakeRequest, L("MakeRequest"));
            leaveRequest.CreateChildPermission(AppPermissions.Pages_Leave_LeaveRequest_Approve, L("ApproveLeaveRequest"));
            leaveRequest.CreateChildPermission(AppPermissions.Pages_Leave_LeaveRequest_Reject, L("RejectLeaveRequest"));
            leaveRequest.CreateChildPermission(AppPermissions.Pages_Leave_LeaveRequest_ViewAll, L("ViewAllLeaveRequest"));
            leaveRequest.CreateChildPermission(AppPermissions.Pages_Leave_LeaveRequest_DeleteAny,
                L("DeleteAnyLeaveRequest"));


            //time
            var time = pages.CreateChildPermission(AppPermissions.Pages_Timing, L("Timing"));

            var attendance = time.CreateChildPermission(AppPermissions.Pages_Timing_Attendances, L("Attendance"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendances_ViewAll, L("ViewAll"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendances_Report, L("AttendanceReport"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendance_PunchIn, L("PunchIn"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendance_PunchOut, L("PunchOut"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendance_Create, L("Create"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendance_Edit, L("Edit"));
            attendance.CreateChildPermission(AppPermissions.Pages_Timing_Attendance_Delete, L("Delete"));

            //performance
            var performance = pages.CreateChildPermission(AppPermissions.Pages_Performance, L("Performance"));

            var keyResultAreas = performance.CreateChildPermission(AppPermissions.Pages_Performance_KeyResultAreas, L("KeyResultAreas"));
            keyResultAreas.CreateChildPermission(AppPermissions.Pages_Performance_KeyResultAreas_Create, L("Create"));
            keyResultAreas.CreateChildPermission(AppPermissions.Pages_Performance_KeyResultAreas_Edit, L("Edit"));
            keyResultAreas.CreateChildPermission(AppPermissions.Pages_Performance_KeyResultAreas_Delete, L("Delete"));

            var performanceRecord = performance.CreateChildPermission(AppPermissions.Pages_Performance_Record, L("PerformanceRecord"));
            performanceRecord.CreateChildPermission(AppPermissions.Pages_Performance_Record_Create, L("Create"));
            performanceRecord.CreateChildPermission(AppPermissions.Pages_Performance_Record_Edit, L("Edit"));
            performanceRecord.CreateChildPermission(AppPermissions.Pages_Performance_Record_Delete, L("Delete"));

            var performanceReport = performance.CreateChildPermission(AppPermissions.Pages_Performance_Report, L("PerformanceReport"));
            performanceReport.CreateChildPermission(AppPermissions.Pages_Performance_Report_ViewAll, L("ViewAll"));
            performanceReport.CreateChildPermission(AppPermissions.Pages_Performance_Report_MyPerformance, L("MyPerformance"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);
            var phoneBook = pages.CreateChildPermission(AppPermissions.Pages_Tenant_PhoneBook, L("PhoneBook"), multiTenancySides: MultiTenancySides.Tenant);
            phoneBook.CreateChildPermission(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson, L("CreateNewPerson"), multiTenancySides: MultiTenancySides.Tenant);
            phoneBook.CreateChildPermission(AppPermissions.Pages_Tenant_PhoneBook_DeletePerson, L("DeletePerson"), multiTenancySides: MultiTenancySides.Tenant);
            
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlueHrmConsts.LocalizationSourceName);
        }
    }
}
