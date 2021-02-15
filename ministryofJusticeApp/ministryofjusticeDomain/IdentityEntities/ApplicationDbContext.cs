using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.IdentityEntities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<DepartmentHead> DepartmentHeads { get; set; }
        public DbSet<AttorneyGeneral> AttorneyGenerals { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}