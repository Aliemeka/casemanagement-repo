using System.Collections.Generic;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        IEnumerable<Department> GetDepartments();

        //Department DeleteDepartment(int departmentId);
        Department GetDepartment(int departmentId);
        //void AddUserToDepartment(string userId, int departmentId);
    }
}