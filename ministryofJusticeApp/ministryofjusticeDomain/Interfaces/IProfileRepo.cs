using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IProfileRepo
    {
        void UpdateProfile(ApplicationUser user, Lawyer lawyer = null, AttorneyGeneral ag = null, DepartmentHead hod = null);
    }
}
