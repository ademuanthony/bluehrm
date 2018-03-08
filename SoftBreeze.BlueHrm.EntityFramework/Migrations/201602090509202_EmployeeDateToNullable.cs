namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDateToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Employees", "LicenseExpiryDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LicenseExpiryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
