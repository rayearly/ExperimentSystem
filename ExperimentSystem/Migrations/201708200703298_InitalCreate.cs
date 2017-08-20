namespace ExperimentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatricNumber = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        ThesisTitle = c.String(nullable: false),
                        ClassGroup = c.String(nullable: false),
                        BatchYear = c.String(nullable: false),
                        Faculty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.String(),
                        Name = c.String(nullable: false),
                        Faculty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupervisorStudents",
                c => new
                    {
                        Supervisor_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supervisor_Id, t.Student_Id })
                .ForeignKey("dbo.Supervisors", t => t.Supervisor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Supervisor_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupervisorStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SupervisorStudents", "Supervisor_Id", "dbo.Supervisors");
            DropIndex("dbo.SupervisorStudents", new[] { "Student_Id" });
            DropIndex("dbo.SupervisorStudents", new[] { "Supervisor_Id" });
            DropTable("dbo.SupervisorStudents");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Students");
        }
    }
}
