namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDateEmployedToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DateEmployed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DateEmployed", c => c.DateTime(nullable: false));
        }
    }
}
