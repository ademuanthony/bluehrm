namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullDateImmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Immigrations", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.Immigrations", "ExpiryDate", c => c.DateTime());
            AlterColumn("dbo.Immigrations", "EligibleReviewDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Immigrations", "EligibleReviewDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Immigrations", "ExpiryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Immigrations", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}
