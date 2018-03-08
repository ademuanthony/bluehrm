namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.KeyResultAreaAttributes", newName: "PerformanceIndicators");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PerformanceIndicators", newName: "KeyResultAreaAttributes");
        }
    }
}
