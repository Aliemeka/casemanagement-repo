using System;
using System.Collections.Generic;
using System.Text;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepo DepartmentRepo { get; }
        IUserManagerRepo UserManagerRepo { get; }
    }
}
