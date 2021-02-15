using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ministryofjusticeWebUi.Models
{
    public class ProfileViewModel
    {
        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string License { get; set; }
    }
}