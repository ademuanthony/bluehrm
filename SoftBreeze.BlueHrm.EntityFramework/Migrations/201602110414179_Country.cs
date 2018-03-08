namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Country : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Counties", newName: "Countries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Countries", newName: "Counties");
        }
    }
}
