namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Code", c => c.String());
            DropColumn("dbo.Currencies", "Symbol");
            DropColumn("dbo.Currencies", "LastModificationTime");
            DropColumn("dbo.Currencies", "LastModifierUserId");
            DropColumn("dbo.Currencies", "CreationTime");
            DropColumn("dbo.Currencies", "CreatorUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Currencies", "CreatorUserId", c => c.Long());
            AddColumn("dbo.Currencies", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Currencies", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.Currencies", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.Currencies", "Symbol", c => c.String());
            DropColumn("dbo.Currencies", "Code");
        }
    }
}
