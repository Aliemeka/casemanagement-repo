using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeWebUi.Models
{
    public class CreateAccountViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}