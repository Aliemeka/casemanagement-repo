using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using static System.Web.HttpContext;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeDomain.Repositories
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepo( ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

       
        /// <summary>
        /// Adds a user to the department
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="departmentId"></param>
        //public void AddUserToDepartment(string userId, byte departmentId)
        //{
        //    var department = _context.Departments.Find(departmentId);
        //    if (department != null)
        //    {
        //        var user = _context.Users.Find(userId);
        //        if (!department.Users.Contains(user))
        //        {
        //            department.Users.ToList().Add(user);
        //            _context.SaveChanges();
        //        }
        //    }
        //}

        //public Department DeleteDepartment(int departmentId)
        //{
        //    var department = _context.Departments.Find(departmentId);
        //    if (department != null)
        //    {
        //        _context.Departments.Remove(department);
        //        _context.SaveChanges();
        //    }

        //    return department;
        //}

        public Department GetDepartment(int departmentId)
        {
            return _context.Departments.Find(departmentId);
        }



        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();

        }
    }
}