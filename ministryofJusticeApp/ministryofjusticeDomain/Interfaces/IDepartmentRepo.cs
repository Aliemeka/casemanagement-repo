using System.Collections.Generic;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetDepartments();
        void AddDepartment(Department department);
        Department DeleteDepartment(byte departmentId);
        Department GetDepartment(byte departmentId);
        void AddUserToDepartment(string userId, byte departmentId);
    }
}
