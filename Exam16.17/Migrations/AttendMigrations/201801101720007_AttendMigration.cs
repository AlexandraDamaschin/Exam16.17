namespace Exam16._17.Migrations.AttendMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(storeType: "date"),
                        SubjectId = c.Int(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        Present = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentSubject",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SubjectId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.LectureSubject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false),
                        LectureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectId, t.LectureId })
                .ForeignKey("dbo.Lecture", t => t.LectureId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.LectureId);
            
            CreateTable(
                "dbo.Lecture",
                c => new
                    {
                        LectureId = c.Int(nullable: false, identity: true),
                        LectureName = c.String(),
                    })
                .PrimaryKey(t => t.LectureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Attendance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.LectureSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.LectureSubject", "LectureId", "dbo.Lecture");
            DropForeignKey("dbo.StudentSubject", "StudentId", "dbo.Student");
            DropIndex("dbo.LectureSubject", new[] { "LectureId" });
            DropIndex("dbo.LectureSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubject", new[] { "StudentId" });
            DropIndex("dbo.Attendance", new[] { "StudentId" });
            DropIndex("dbo.Attendance", new[] { "SubjectId" });
            DropTable("dbo.Lecture");
            DropTable("dbo.LectureSubject");
            DropTable("dbo.Subject");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.Student");
            DropTable("dbo.Attendance");
        }
    }
}
