using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ministryofjusticeDomain.IdentityEntities;

namespace ministryofjusticeDomain.Entities
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}