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

        public UnitOfWork(IDepartmentRepo departmentRepo,
            IUserManagerRepo userManagerRepo,
            IRoleService roleService)
        {
           
            DepartmentRepo = departmentRepo;
            UserManagerRepo = userManagerRepo;
            RoleService = roleService;
        }
    }
}
