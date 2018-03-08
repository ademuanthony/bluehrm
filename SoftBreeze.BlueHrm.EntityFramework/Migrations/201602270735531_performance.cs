namespace SoftBreeze.BlueHrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class performance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConcludingRemarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerformanceId = c.Int(nullable: false),
                        Question = c.String(),
                        Answer = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffPerformances", t => t.PerformanceId, cascadeDelete: true)
                .Index(t => t.PerformanceId);
            
            CreateTable(
                "dbo.StaffPerformances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Long(nullable: false),
                        PeriodId = c.Int(nullable: false),
                        AttitudeToWork = c.String(),
                        MostImportantAreasForImprovment = c.String(),
                        OtherImportantComment = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.PerformanceEvaluationPeriods", t => t.PeriodId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PeriodId);
            
            CreateTable(
                "dbo.PerformanceEvaluationPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeyResultAreaAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeyResultAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerformanceId = c.Int(nullable: false),
                        AttributeId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ActualAcheivement = c.String(),
                        Comment = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KeyResultAreaAttributes", t => t.AttributeId, cascadeDelete: true)
                .ForeignKey("dbo.StaffPerformances", t => t.PerformanceId, cascadeDelete: true)
                .Index(t => t.PerformanceId)
                .Index(t => t.AttributeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyResultAreas", "PerformanceId", "dbo.StaffPerformances");
            DropForeignKey("dbo.KeyResultAreas", "AttributeId", "dbo.KeyResultAreaAttributes");
            DropForeignKey("dbo.ConcludingRemarks", "PerformanceId", "dbo.StaffPerformances");
            DropForeignKey("dbo.StaffPerformances", "PeriodId", "dbo.PerformanceEvaluationPeriods");
            DropForeignKey("dbo.StaffPerformances", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.KeyResultAreas", new[] { "AttributeId" });
            DropIndex("dbo.KeyResultAreas", new[] { "PerformanceId" });
            DropIndex("dbo.StaffPerformances", new[] { "PeriodId" });
            DropIndex("dbo.StaffPerformances", new[] { "EmployeeId" });
            DropIndex("dbo.ConcludingRemarks", new[] { "PerformanceId" });
            DropTable("dbo.KeyResultAreas");
            DropTable("dbo.KeyResultAreaAttributes");
            DropTable("dbo.PerformanceEvaluationPeriods");
            DropTable("dbo.StaffPerformances");
            DropTable("dbo.ConcludingRemarks");
        }
    }
}
