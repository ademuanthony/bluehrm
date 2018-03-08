namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveRequestMap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveRequests", "LeaveTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveRequests", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LeaveRequests", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LeaveRequests", "EmployeeId", c => c.Long(nullable: false));
            CreateIndex("dbo.LeaveRequests", "EmployeeId");
            CreateIndex("dbo.LeaveRequests", "LeaveTypeId");
            AddForeignKey("dbo.LeaveRequests", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LeaveRequests", "LeaveTypeId", "dbo.LeaveTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveRequests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.LeaveRequests", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeId" });
            AlterColumn("dbo.LeaveRequests", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.LeaveRequests", "EndDate");
            DropColumn("dbo.LeaveRequests", "StartDate");
            DropColumn("dbo.LeaveRequests", "LeaveTypeId");
        }
    }
}
