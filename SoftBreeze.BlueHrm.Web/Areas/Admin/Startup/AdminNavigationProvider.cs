using Abp.Application.Navigation;
using Abp.Localization;
using SoftBreeze.BlueHrm.Authorization;
using SoftBreeze.BlueHrm.Web.Navigation;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Startup
{
    public class AdminNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Mpa";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            menu
                .AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Tenants,
                    L("Tenants"),
                    url: "Admin/Tenants",
                    icon: "icon-globe",
                    requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Editions,
                    L("Editions"),
                    url: "Admin/Editions",
                    icon: "icon-grid",
                    requiredPermissionName: AppPermissions.Pages_Editions
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("Dashboard"),
                    url: "Admin/Dashboard",
                    icon: "icon-home",
                    requiredPermissionName: AppPermissions.Pages_Tenant_Dashboard
                    )
                )
                /*.AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.BlueHrm,
                    L("PhoneBook"),
                    url: "Admin/PhoneBook",
                    icon: "glyphicon glyphicon-book",
                    requiredPermissionName: AppPermissions.Pages_Tenant_PhoneBook
                    )
                )*/

            #region admin

                .AddItem(new MenuItemDefinition(
                    PageNames.App.Admin.Administration,
                    L("Administration"),
                    icon: "icon-wrench"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Admin.Roles,
                        L("Roles"),
                        url: "Admin/Roles",
                        icon: "icon-briefcase",
                        requiredPermissionName: AppPermissions.Pages_Administration_Roles
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Admin.Users,
                        L("Users"),
                        url: "Admin/Users",
                        icon: "icon-users",
                        requiredPermissionName: AppPermissions.Pages_Administration_Users
                        )
                    )

                    //Job Config
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Admin.JobConfiguration.Base,
                        L("JobConfig"),
                        icon: "fa fa-columns"
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.JobConfiguration.JobTitles,
                            L("JobTitles"),
                            url: "Admin/JobTitles",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_JobConfiguration_JobTitle
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.JobConfiguration.PayGrades,
                            L("PayGrades"),
                            url: "Admin/PayGrades",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_JobConfiguration_PayGrade
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.JobConfiguration.EmployeeStatuses,
                            L("EmployeeStatuses"),
                            url: "Admin/EmployeeStatuses",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_JobConfiguration_EmployeeStatus
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.JobConfiguration.JobCategories,
                            L("JobCategories"),
                            url: "Admin/JobCategories",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_JobConfiguration_JobCategories
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.JobConfiguration.JobTerminationReasons,
                            L("JobTerminationReasons"),
                            url: "Admin/JobTerminationReasons",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_JobConfiguration_JobTerminationReasons
                            )
                        )
                    )

                    /*Organisation*/
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Admin.Organisation.Base,
                        L("Organisation"),
                        icon: "fa fa-institution"
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.Organisation.GeneralInformation,
                            L("GeneralInformation"),
                            url: "Admin/GeneralInformation",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_Organisation_GeneralInformation
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.Organisation.Locations,
                            L("Locations"),
                            url: "Admin/Locations",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_Organisation_Locations
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.Organisation.Units,
                            L("Units"),
                            url: "Admin/Units",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_Organisation_Units
                            )
                        )
                   )

                   /*Qualification*/
                   .AddItem(new MenuItemDefinition(
                        PageNames.App.Admin.Qualification.Base,
                        L("Qualification"),
                        icon: "fa fa-tags"
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.Qualification.Skills,
                            L("Skills"),
                            url: "Admin/Skills",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_Qualification_Skills
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.Qualification.EducationalLevels,
                            L("EducationalLevels"),
                            url: "Admin/EducationalLevels",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_Qualification_EducationalLevel
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                            PageNames.App.Admin.Qualification.Licenses,
                            L("Licenses"),
                            url: "Admin/Licenses",
                            icon: "fa fa-certificate",
                            requiredPermissionName: AppPermissions.Pages_Administration_Qualification_Licenses
                            )
                        )


                   )



                    /* 
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Languages,
                        L("Languages"),
                        url: "Admin/Languages",
                        icon: "icon-flag",
                        requiredPermissionName: AppPermissions.Pages_Administration_Languages
                        )
                    )*/

                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Admin.AuditLogs,
                        L("AuditLogs"),
                        url: "Admin/AuditLogs",

                        icon: "icon-lock",
                        requiredPermissionName: AppPermissions.Pages_Administration_AuditLogs
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Settings,
                        L("Settings"),
                        url: "Admin/HostSettings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Settings
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Tenant.Settings,
                        L("Settings"),
                        url: "Admin/Settings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Tenant_Settings
                        )
                    )
                )
            #endregion

                .AddItem(new MenuItemDefinition(
                    PageNames.App.Admin.Administration,
                    L("Pim"),
                    icon: "icon-user"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Pim.EmployeeList,
                        L("EmployeeList"),
                        url: "Pim/EmployeeList",
                        icon: "icon-users",
                        requiredPermissionName: AppPermissions.Pages_Pim_Eployees
                        )
                    )
                    //.AddItem(new MenuItemDefinition(
                    //    PageNames.App.Pim.Report,
                    //    L("Report"),
                    //    url: "Pim/Report",
                    //    icon: "fa  fa-folder-open",
                    //    requiredPermissionName: AppPermissions.Pages_Pim_Report
                    //    )
                    //)
                )
                .AddItem(new MenuItemDefinition(PageNames.App.Leave.Base,
                    L("Leave"),
                    "fa fa-bed"
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Leave.LeaveTypes,
                        L("LeaveTypes"),
                        url: "Leave/Types",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Leave_LeaveTypes
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Leave.LeaveEntitlements,
                        L("LeaveEntitlements"),
                        url: "Leave/Entitlements",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Leave_LeaveEntitlements
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Leave.LeaveList,
                        L("LeaveList"),
                        url: "Leave/LeaveList",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Leave
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Leave.Requests,
                        L("Requests"),
                        url: "Leave/Request",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Leave_LeaveRequest
                        )
                    )
                 )
                .AddItem(new MenuItemDefinition(PageNames.App.Timing.Base,
                    L("Time"),
                    "fa fa-clock-o"
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Timing.Attendance,
                        L("AttendanceLog"),
                        url: "Time/Attendance",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Timing_Attendances
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Timing.AttendanceReport,
                        L("AttendanceReport"),
                        url: "Time/Attendance/Report",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Timing_Attendances_Report
                        )
                    )
                 )
                .AddItem(new MenuItemDefinition(PageNames.App.Performance.Base,
                    L("Performance"),
                    "fa fa-cubes"
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Performance.KeyResultAreas,
                        L("KeyPerformanceIndicator"),
                        url: "Performance/Indicators",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Performance_KeyResultAreas
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Performance.Record,
                        L("PerformanceRecord"),
                        url: "Performance/Record",
                        icon: "fa fa-certificate",
                        requiredPermissionName: AppPermissions.Pages_Performance_Record
                        )
                    )
                 )
                 ;
        }
        //KeyResultAreas
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlueHrmConsts.LocalizationSourceName);
        }
    }
}