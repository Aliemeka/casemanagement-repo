using System.Collections.Generic;

namespace ministryofjusticeDomain.Entities
{
    public class Department
    {
        public byte Id { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}