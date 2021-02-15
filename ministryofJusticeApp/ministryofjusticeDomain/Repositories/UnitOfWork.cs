using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeDomain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly ApplicationDbContext _context;

        public IDepartmentRepo DepartmentRepo { get; }
        public IUserManagerRepo UserManagerRepo { get; }
        public IRoleService RoleService { get; }
        public IProfileRepo ProfileRepo { get; set; }

        public UnitOfWork(IDepartmentRepo departmentRepo,
            IUserManagerRepo userManagerRepo,
            IRoleService roleService,
            IProfileRepo profileRepo)
        {
           
            DepartmentRepo = departmentRepo;
            UserManagerRepo = userManagerRepo;
            RoleService = roleService;
            ProfileRepo = profileRepo;
        }
    }
}
