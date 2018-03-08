using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.Authorization.Roles;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.LeaveModule;
using SoftBreeze.BlueHrm.MultiTenancy;
using SoftBreeze.BlueHrm.Organization;
using SoftBreeze.BlueHrm.People;
using SoftBreeze.BlueHrm.Performance;
using SoftBreeze.BlueHrm.PersonalInformation;
using SoftBreeze.BlueHrm.Storage;
using SoftBreeze.BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration.Payrol;
using SoftBreeze.BlueHrm.TimeModule;

namespace SoftBreeze.BlueHrm.EntityFramework
{
     
    public class BlueHrmDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        //time
        public IDbSet<Attendance> Attendances { get; set; } 

        //job configurations
        public IDbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<JobCategory> JobCategories { get; set; }
        public IDbSet<JobTerminationReason> JobTerminationReasons { get; set; }
        public IDbSet<PayGrade> PayGrades { get; set; }

        //Organisation  
        public IDbSet<GeneralInformation> GeneralInformations { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Unit> Units { get; set; }


        //Personal Inforation
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<Dependant> Dependants { get; set; }
        public IDbSet<Education> Educations { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<EmployeeAttachement> EmployeeAttachements { get; set; }
        public IDbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public IDbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public IDbSet<EmployeeMembership> EmployeeMemberships { get; set; }
        public IDbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public IDbSet<Immigration> Immigrations { get; set; }
        public IDbSet<JobExperience> JobExperiences { get; set; }
        public IDbSet<JobInformation> JobInformations { get; set; }
        public IDbSet<License> Licenses { get; set; }
        public IDbSet<Salary> Salaries { get; set; }
        public IDbSet<Supervisor> Supervisors { get; set; }

        //system configuration
        //**payroll
        public IDbSet<SalaryComponent> SalaryComponents { get; set; }
        public IDbSet<SalaryPayFrequency> SalaryPayFrequencies { get; set; }
        //**others
        public IDbSet<Country> Counties { get; set; }
        public IDbSet<Currency> Currencies { get; set; }
        public IDbSet<EducationalLevel> EducationalLevels { get; set; }
        public IDbSet<BlueHrmLanguage> BlueHrmLanguages { get; set; }
        public IDbSet<LicenseType> LicenseTypes { get; set; }
        public IDbSet<Membership> Memberships { get; set; }
        public IDbSet<Skill> Skills { get; set; }

        //Leave module
        public IDbSet<Leave> Leaves { get; set; }
        public IDbSet<LeaveEntitlement> LeaveEntitlments { get; set; }
        public IDbSet<LeaveRequest> LeaveRequests { get; set; }
        public  IDbSet<LeaveRequestComment> LeaveRequestComments { get; set; }
        public IDbSet<LeaveType> LeaveTypes { get; set; }     
        public IDbSet<LeavePeriod> LeavePeriods { get; set; }

        //performance
        public IDbSet<ConcludingRemark> ConcludingRemarks { get; set; } 
        public IDbSet<KeyResultArea> KeyResultAreas { get; set; } 
        public IDbSet<PerformanceIndicator> PerformanceIndicators { get; set; }
        public IDbSet<PerformanceEvaluationPeriod> PerformanceEvaluationPeriods { get; set; } 
        public IDbSet<StaffPerformance> Performances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure relationships

            //user to employee
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<User>()
                        .HasOptional(e => e.Employee)
                        .WithRequired(con => con.User);

            //employee supervisor and subordinate
            modelBuilder.Entity<Supervisor>()
                .HasRequired(supervisor => supervisor.Employee)
                .WithMany(employee => employee.Supervisors)
                .HasForeignKey(supervisor => supervisor.EmployeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supervisor>()
                .HasRequired(supervisor => supervisor.SupervisingEmployee)
                .WithMany(employee => employee.Subordinates)
                .HasForeignKey(supervisor => supervisor.SupervisorId)
                .WillCascadeOnDelete(false);

            //employee to contact
            modelBuilder.Entity<Contact>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Employee>()
                        .HasOptional(e => e.Contact)
                        .WithRequired(con => con.Employee);

            //employee to job information
            modelBuilder.Entity<JobInformation>()
                .HasKey(j => j.Id);
            modelBuilder.Entity<Employee>()
                        .HasOptional(e => e.JobInformation)
                        .WithRequired(j => j.Employee);

            //employee to job termination
            modelBuilder.Entity<JobTermination>()
                .HasKey(j => j.Id);
            modelBuilder.Entity<Employee>()
                        .HasOptional(e => e.JobTermination)
                        .WithRequired(j => j.Employee);


            base.OnModelCreating(modelBuilder);
        }





        /* Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         * But it may cause problems when working Migrate.exe of EF. ABP works either way.         * 
         */
        public BlueHrmDbContext()
            : base("Default")
        {

        }

        /* This constructor is used by ABP to pass connection string defined in PhoneBookDataModule.PreInitialize.
         * Notice that, actually you will not directly create an instance of PhoneBookDbContext since ABP automatically handles it.
         */
        public BlueHrmDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection.
         */
        public BlueHrmDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }

}
