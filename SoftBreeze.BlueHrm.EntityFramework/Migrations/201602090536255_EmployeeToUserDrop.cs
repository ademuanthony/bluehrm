namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeToUserDrop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Id", "dbo.AbpUsers");
            DropForeignKey("dbo.Contacts", "Id", "dbo.Employees");
            DropForeignKey("dbo.JobInformations", "Id", "dbo.Employees");
            DropForeignKey("dbo.JobTerminations", "Id", "dbo.Employees");
            DropForeignKey("dbo.Dependants", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Educations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeAttachements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeEmergencyContacts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeMemberships", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSkills", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Immigrations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.JobExperiences", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Licenses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Id" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Id");
            AddForeignKey("dbo.Contacts", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.JobInformations", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.JobTerminations", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Dependants", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Educations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAttachements", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeEmergencyContacts", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeMemberships", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSkills", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Immigrations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobExperiences", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Licenses", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Licenses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.JobExperiences", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Immigrations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSkills", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeMemberships", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeEmergencyContacts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeAttachements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Educations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Dependants", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.JobTerminations", "Id", "dbo.Employees");
            DropForeignKey("dbo.JobInformations", "Id", "dbo.Employees");
            DropForeignKey("dbo.Contacts", "Id", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Licenses", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobExperiences", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Immigrations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSkills", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeMemberships", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeEmergencyContacts", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAttachements", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Educations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Dependants", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobTerminations", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.JobInformations", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Contacts", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Id", "dbo.AbpUsers", "Id");
        }
    }
}
