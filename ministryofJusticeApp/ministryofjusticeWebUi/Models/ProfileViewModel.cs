using System.ComponentModel.DataAnnotations;

namespace ministryofjusticeWebUi.Models
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "You have to enter your first name")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to enter your last name")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You have to enter your current password")]
        [Display(Name = "Current Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "You have to enter a new password")]
        [Display(Name = "New password")]
        [DataType(DataType.Password, ErrorMessage = "Password must have at least one character, one number and one special character")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You have to confirm your password")]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Company email address")]
        [Required]
        [Editable(false)]
        public string Email { get; set; }
        public string License { get; set; }
    }
}