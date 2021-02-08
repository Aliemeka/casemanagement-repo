namespace ministryofjusticeWebUi.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ministryofjusticeWebUi.HelperMethods;
    using ministryofjusticeWebUi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ministryofjusticeWebUi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ministryofjusticeWebUi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Seeding of Roles  

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var role = new CreateRoleService(context);

            role.CreateRoles("System Administrator");
            role.CreateRoles("Attorney General");
            role.CreateRoles("Director of Department");
            role.CreateRoles("Lawyer");

            var systemAdmin = new ApplicationUser()
            {
                UserName = "SystemAdmin",
                Email = "systemadmin@ministryofjustice.com",
                EmailConfirmed = true
            };

            //Creates a User and assign it to the role of  System Admin
            var result = manager.Create(systemAdmin, "Zxcvbn55@");
            if (result.Succeeded)
            {
                manager.AddToRole(systemAdmin.Id, "System Administrator");
            }

            var attorney = new ApplicationUser()
            {
                UserName = "AttorneyGeneral",
                Email = "attorneygeneral@ministryofjustice.com",
                EmailConfirmed = true
            };

            //Creates a User and assign it to the role of Attorney General

            result = manager.Create(attorney, "ASdf:lkj");
            if (result.Succeeded)
            {
                manager.AddToRole(attorney.Id, "Attorney General");
            }



        }
    }
}
