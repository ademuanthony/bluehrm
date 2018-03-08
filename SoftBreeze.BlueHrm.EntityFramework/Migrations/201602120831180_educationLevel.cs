namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class educationLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "LevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Educations", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Educations", "EndDate", c => c.DateTime());
            CreateIndex("dbo.Educations", "LevelId");
            AddForeignKey("dbo.Educations", "LevelId", "dbo.EducationalLevels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "LevelId", "dbo.EducationalLevels");
            DropIndex("dbo.Educations", new[] { "LevelId" });
            AlterColumn("dbo.Educations", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Educations", "LevelId");
        }
    }
}
