namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LEaveUPdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Leaves", "Comment", c => c.String());
            AddColumn("dbo.Leaves", "NumberOfDays", c => c.Int(nullable: false));
            DropColumn("dbo.Leaves", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "EmployeeId", c => c.Long(nullable: false));
            DropColumn("dbo.Leaves", "NumberOfDays");
            DropColumn("dbo.Leaves", "Comment");
            DropColumn("dbo.Leaves", "Status");
        }
    }
}
