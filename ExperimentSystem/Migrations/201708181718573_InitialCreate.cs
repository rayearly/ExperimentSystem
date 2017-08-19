namespace ExperimentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        MatricNumber = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThesisTitle = c.String(),
                        ClassGroup = c.String(),
                        BatchYear = c.String(),
                        Faculty = c.String(),
                    })
                .PrimaryKey(t => t.MatricNumber);
            
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Faculty = c.String(),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.SupervisorStudents",
                c => new
                    {
                        Supervisor_StaffId = c.Int(nullable: false),
                        Student_MatricNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supervisor_StaffId, t.Student_MatricNumber })
                .ForeignKey("dbo.Supervisors", t => t.Supervisor_StaffId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_MatricNumber, cascadeDelete: true)
                .Index(t => t.Supervisor_StaffId)
                .Index(t => t.Student_MatricNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupervisorStudents", "Student_MatricNumber", "dbo.Students");
            DropForeignKey("dbo.SupervisorStudents", "Supervisor_StaffId", "dbo.Supervisors");
            DropIndex("dbo.SupervisorStudents", new[] { "Student_MatricNumber" });
            DropIndex("dbo.SupervisorStudents", new[] { "Supervisor_StaffId" });
            DropTable("dbo.SupervisorStudents");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Students");
        }
    }
}
