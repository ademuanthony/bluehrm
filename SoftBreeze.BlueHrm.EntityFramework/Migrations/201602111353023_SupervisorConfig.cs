namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupervisorConfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees");
            AlterColumn("dbo.Supervisors", "SupervisorId", c => c.Long(nullable: false));
            CreateIndex("dbo.Supervisors", "SupervisorId");
            AddForeignKey("dbo.Supervisors", "SupervisorId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Supervisors", "SupervisorId", "dbo.Employees");
            DropIndex("dbo.Supervisors", new[] { "SupervisorId" });
            AlterColumn("dbo.Supervisors", "SupervisorId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Supervisors", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
