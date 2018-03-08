namespace SoftBreeze.BlueHrm.Web.Navigation
{
    public static class PageNames
    {
        public static class App
        {
            public static class Admin
            {
                public const string Administration = "Administration";
                public const string Roles = "Administration.Roles";
                public const string Users = "Administration.Users";
                public const string AuditLogs = "Administration.AuditLogs";
                public const string Languages = "Administration.Languages";


                public static class JobConfiguration
                {
                    public const string Base = "Administration.JobConfiguration";
                    public const string JobTitles = "Administration.JobConfiguration.JobTitles";
                    public const string PayGrades = "Administration.JobConfiguration.PayGrades";
                    public const string EmployeeStatuses = "Administration.JobConfiguration.EmployeeStatuses";
                    public const string JobCategories = "Administration.JobConfiguration.JobCategories";
                    public const string JobTerminationReasons = "Administration.JobConfiguration.JobTerminationReasons";
                }

                public static class Organisation
                {
                    public const string Base = "Administration.Organisation";
                    public const string GeneralInformation = "Administration.Organisation.GeneralInformation";
                    public const string Locations = "Administration.Organisation.Locations";
                    public const string Units = "Administration.Organisation.Units";
                }

                public static class Qualification
                {
                    public const string Base = "Administration.Qualification";
                    public const string Skills = "Administration.Qualification.Skills";
                    public const string EducationalLevels = "Administration.Qualification.EducationalLevels";
                    public const string Licenses = "Administration.Qualification.Licenses";
                }

            }

            public static class Pim
            {
                public const string EmployeeList = "Pim.EmployeeList";
                public const string Report = "Pim.Report";
            }
            
            public static class Host
            {
                public const string Tenants = "Tenants";
                public const string Editions = "Editions";
                public const string Settings = "Administration.Settings.Host";
            }

            public static class Tenant
            {
                public const string Dashboard = "Dashboard.Tenant";
                public const string Settings = "Administration.Settings.Tenant";
                public const string BlueHrm = "Phonebook";
            }

            public class Leave
            {
                public const string Base = "Leave";
                public const string Requests = "Leave.Requests";
                public const string LeaveTypes = "Leave.LeaveTypes";
                public const string LeaveEntitlements = "Leave.LeaveEntitlements";
                public const string LeaveList = "Leave.LeaveList";
            }
            
            public class Timing
            {
                public const string Base = "Timing";
                public const string Attendance = "Timing.Attendance";
                public const string AttendanceReport = "Timing.Attendance.Report";
            }
            
            public class Performance 
            {
                public const string Base = "Performance";
                public const string KeyResultAreas = "Performance.KeyResultAreas";
                public const string Record = "Performance.Record";
                public const string Report = "Performance.Report";
            }
        }

        public static class Frontend
        {
            public const string Home = "Frontend.Home";
            public const string About = "Frontend.About";
        }
    }
}