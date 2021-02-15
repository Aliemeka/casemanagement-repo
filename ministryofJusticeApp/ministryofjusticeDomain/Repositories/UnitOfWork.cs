using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeDomain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IDepartmentRepo DepartmentRepo { get; }
        public IUserManagerRepo UserManagerRepo { get; }
        public IRoleService RoleService { get; }
        public IProfileRepo ProfileRepo { get; set; }

        public UnitOfWork(ApplicationDbContext context,
            IDepartmentRepo departmentRepo,
            IUserManagerRepo userManagerRepo,
            IRoleService roleService,
            IProfileRepo profileRepo)
        {
            _context = context;
            DepartmentRepo = departmentRepo;
            UserManagerRepo = userManagerRepo;
            RoleService = roleService;
            ProfileRepo = profileRepo;
        }
    }
}
