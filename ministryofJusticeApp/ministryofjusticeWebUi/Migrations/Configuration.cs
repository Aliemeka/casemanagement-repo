namespace ministryofjusticeWebUi.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ministryofjusticeDomain.Services;
    using ministryofjusticeDomain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Seeding of Roles  

            context.Departments.AddOrUpdate(department => department.Id,
                new Department()
                {
                    Id = 1,
                    DepartmentName = "Administration"
                },
                new Department()
                {
                    Id = 2,
                    DepartmentName = "Attorney General"
                }
            );

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var role = new RoleService(context);

            role.CreateRoles("System Administrator");
            role.CreateRoles("Attorney General");
            role.CreateRoles("Director of Department");
            role.CreateRoles("Lawyer");

            var systemAdmin = new ApplicationUser()
            {
                UserName = "systemadmin@ministryofjustice.com",
                Email = "systemadmin@ministryofjustice.com",
                EmailConfirmed = true
            };

            //Creates a User and assign it to the role of  System Admin
            var result = manager.Create(systemAdmin, " " +
                                                     "");
            if (result.Succeeded) manager.AddToRole(systemAdmin.Id, "System Administrator");

            var attorney = new ApplicationUser()
            {
                UserName = "attorneygeneral@ministryofjustice.com",
                Email = "attorneygeneral@ministryofjustice.com",
                EmailConfirmed = true
            };

            //Creates a User and assign it to the role of Attorney General

            result = manager.Create(attorney, "ASdf:lkj");
            if (result.Succeeded) manager.AddToRole(attorney.Id, "Attorney General");
        }
    }
}