using System;
using System.Collections.Generic;
using System.Text;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IProfileRepo
    {
        void UpdateProfile(ApplicationUser user, Lawyer lawyer, AttorneyGeneral ag, DepartmentHead hod);
    }
}
