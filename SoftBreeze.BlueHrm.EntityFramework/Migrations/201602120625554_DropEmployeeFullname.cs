namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEmployeeFullname : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Fullname", c => c.String());
        }
    }
}
