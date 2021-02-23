using System;
using ministryofjusticeDomain.IdentityEntities;

namespace ministryofjusticeDomain.Entities
{
    public class Lawyer
    {
        public int Id { get; set; }
        public string License { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime TimeRegister { get; set; }
    }
}
