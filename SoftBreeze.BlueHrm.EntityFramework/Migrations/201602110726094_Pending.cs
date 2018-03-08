namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pending : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SalaryComponents", "LastModificationTime");
            DropColumn("dbo.SalaryComponents", "LastModifierUserId");
            DropColumn("dbo.SalaryComponents", "CreationTime");
            DropColumn("dbo.SalaryComponents", "CreatorUserId");
            DropColumn("dbo.SalaryPayFrequencies", "LastModificationTime");
            DropColumn("dbo.SalaryPayFrequencies", "LastModifierUserId");
            DropColumn("dbo.SalaryPayFrequencies", "CreationTime");
            DropColumn("dbo.SalaryPayFrequencies", "CreatorUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalaryPayFrequencies", "CreatorUserId", c => c.Long());
            AddColumn("dbo.SalaryPayFrequencies", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalaryPayFrequencies", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.SalaryPayFrequencies", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.SalaryComponents", "CreatorUserId", c => c.Long());
            AddColumn("dbo.SalaryComponents", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalaryComponents", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.SalaryComponents", "LastModificationTime", c => c.DateTime());
        }
    }
}
