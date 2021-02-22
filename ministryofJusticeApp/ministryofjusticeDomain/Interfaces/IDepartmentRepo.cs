using System.Collections.Generic;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetDepartments();
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        Department DeleteDepartment(int departmentId);
        Department GetDepartment(int departmentId);
        //void AddUserToDepartment(string userId, int departmentId);
    }
}
