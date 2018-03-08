namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveEntitlement : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LeaveEntitlments", newName: "LeaveEntitlements");
            CreateTable(
                "dbo.LeavePeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LeaveEntitlements", "PeriodId", c => c.Int(nullable: false));
            CreateIndex("dbo.LeaveEntitlements", "PeriodId");
            AddForeignKey("dbo.LeaveEntitlements", "PeriodId", "dbo.LeavePeriods", "Id", cascadeDelete: true);
            DropColumn("dbo.LeaveEntitlements", "LeavePeriodStartDate");
            DropColumn("dbo.LeaveEntitlements", "LeavePeriodEndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveEntitlements", "LeavePeriodEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LeaveEntitlements", "LeavePeriodStartDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.LeaveEntitlements", "PeriodId", "dbo.LeavePeriods");
            DropIndex("dbo.LeaveEntitlements", new[] { "PeriodId" });
            DropColumn("dbo.LeaveEntitlements", "PeriodId");
            DropTable("dbo.LeavePeriods");
            RenameTable(name: "dbo.LeaveEntitlements", newName: "LeaveEntitlments");
        }
    }
}
