using System;
using System.Collections.Generic;
using System.Linq;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeDomain.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        /// <summary>
        /// Adds a user to the department
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="departmentId"></param>
        public void AddUserToDepartment(string userId, byte departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            if (department != null)
            {
                var user = _context.Users.Find(userId);
                if (!department.Users.Contains(user))
                {
                    department.Users.ToList().Add(user);
                    _context.SaveChanges();
                }
            }
        }

        public Department DeleteDepartment(byte departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }

            return department;
        }

        public Department GetDepartment(byte departmentId)
        {
            return _context.Departments.Find(departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments;
        }
    }
}
