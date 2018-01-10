namespace Exam16._17.Migrations.AttendMigrations
{
    using Models.StudentLectureModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.StudentLectureModel.AttendDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AttendMigrations";
        }

        protected override void Seed(Models.StudentLectureModel.AttendDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SeedSubjects(context);
        }

        private void SeedSubjects(AttendDBContext context)
        {
            context.Subjects.AddOrUpdate(
                s => s.SubjectId,
                new Subject { SubjectName = "RAD" },
                new Subject { SubjectName = "Web" },
                new Subject { SubjectName = "Database" },
                new Subject { SubjectName = "Soft Prj Mgm" }
                );
            context.SaveChanges();
        }
    }
}
