namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeMembershipEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeMemberships", "SuscriptionStartDate", c => c.DateTime());
            AlterColumn("dbo.EmployeeMemberships", "SuscriptionRenewalDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeMemberships", "SuscriptionRenewalDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeMemberships", "SuscriptionStartDate", c => c.DateTime(nullable: false));
        }
    }
}
