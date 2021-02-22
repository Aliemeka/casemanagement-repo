using System.ComponentModel.DataAnnotations.Schema;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasKey(d => d.Id)
                .Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName)
                .HasMaxLength(255);
            base.OnModelCreating(modelBuilder);
        }
    }
}