namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KeyResultAreas", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KeyResultAreas", "Rating", c => c.Int(nullable: false));
        }
    }
}
