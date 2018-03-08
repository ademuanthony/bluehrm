namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImmigrationCorrection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Immigrations", "Document", c => c.Int(nullable: false));
            DropColumn("dbo.Immigrations", "Docuent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Immigrations", "Docuent", c => c.Int(nullable: false));
            DropColumn("dbo.Immigrations", "Document");
        }
    }
}
