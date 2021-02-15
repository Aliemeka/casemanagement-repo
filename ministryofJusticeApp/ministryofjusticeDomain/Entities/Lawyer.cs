using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ministryofjusticeDomain.Entities
{
    public class Lawyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string License { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime TimeRegister { get; set; }
    }
}
