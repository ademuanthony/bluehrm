namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Leave : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveEntitlments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        LeaveTypeId = c.Int(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        LeavePeriodStartDate = c.DateTime(nullable: false),
                        LeavePeriodEndDate = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.LeaveTypeId);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsEntitlementSituational = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveRequestComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        RequestId = c.Int(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Note = c.String(),
                        Status = c.Int(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        EntitlementId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveEntitlments", t => t.EntitlementId, cascadeDelete: true)
                .Index(t => t.EntitlementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "EntitlementId", "dbo.LeaveEntitlments");
            DropForeignKey("dbo.LeaveRequestComments", "RequestId", "dbo.LeaveRequests");
            DropForeignKey("dbo.LeaveEntitlments", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveEntitlments", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Leaves", new[] { "EntitlementId" });
            DropIndex("dbo.LeaveRequestComments", new[] { "RequestId" });
            DropIndex("dbo.LeaveEntitlments", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveEntitlments", new[] { "EmployeeId" });
            DropTable("dbo.Leaves");
            DropTable("dbo.LeaveRequests");
            DropTable("dbo.LeaveRequestComments");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.LeaveEntitlments");
        }
    }
}
