namespace Exam16._17.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
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
            //SeedUsers(context);
           // SeedRoles(context);
        }
        private void SeedRoles(ApplicationDbContext context)
        {

            var manager =
             new UserManager<ApplicationUser>(
                 new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            //create roles
            roleManager.Create(new IdentityRole { Name = "Lecture" });
            roleManager.Create(new IdentityRole { Name = "Student" });

            //asign roles to users
            ApplicationUser lecture = manager.FindByEmail("john.k@itsligo.ie");
            if (lecture != null)
            {
                manager.AddToRoles(lecture.Id, new string[] { "Lecture" });
            }
            else
            {
                throw new Exception { Source = "Did not find lecture" };
            }

            ApplicationUser student = manager.FindByEmail("S01@itsligo.ie");
            if (student != null)
            {
                manager.AddToRoles(student.Id, new string[] { "Student" });
            }
            else
            {
                throw new Exception { Source = "Did not find student" };
            }
            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            //seeding two applicationUsers
            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "john.k@itsligo.ie",
                EmailConfirmed = true,
                UserName = "john.k@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$1"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S01@itsligo.ie",
                EmailConfirmed = true,
                UserName = "S01@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$2"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
        }
    }
}
