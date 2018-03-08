namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PerformanceEvaluationStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StaffPerformances", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StaffPerformances", "Status");
        }
    }
}
