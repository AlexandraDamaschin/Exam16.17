namespace Exam16._17.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  Run this seeds in order to get users and roles for users
            //SeedUsers(context);
            //SeedRoles(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            //seeding two applicationUsers
            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "ion.popescu@ulbsibiu.ro",
                EmailConfirmed = true,
                UserName = "ion.popescu@ulbsibiu.ro",
                PasswordHash = new PasswordHasher().HashPassword("UlbsSibiu1$"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "alexandra.damaschin@ulbsibiu.ro",
                EmailConfirmed = true,
                UserName = "alexandra.damaschin@ulbsibiu.ro",
                PasswordHash = new PasswordHasher().HashPassword("UlbsSibiu1$"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
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
            ApplicationUser lecture = manager.FindByEmail("ion.popescu@ulbsibiu.ro");
            if (lecture != null)
            {
                manager.AddToRoles(lecture.Id, new string[] { "Lecture" });
            }
            else
            {
                throw new Exception { Source = "Did not find lecture" };
            }

            ApplicationUser student = manager.FindByEmail("alexandra.damaschin@ulbsibiu.ro");
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
    }
}
