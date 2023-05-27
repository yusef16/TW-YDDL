using System.ComponentModel.DataAnnotations;

namespace siteComponente.Web.Models
{
     public class RegisterForm
     {
          [Display(Name = "Username")]
          [Required(ErrorMessage = "You need to give us your USERNAME.")]
          public string Username { get; set; }

          [Display(Name = "Password")]
          [Required(ErrorMessage = "You must have a password.")]
          [DataType(DataType.Password)]
          [StringLength(100, MinimumLength = 10, ErrorMessage = "You need to provide a long enough password.")]
          public string Password { get; set; }

          [Display(Name = "Confirm Password")]
          [DataType(DataType.Password)]
          [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
          public string confirmPassword { get; set; }

          [DataType(DataType.EmailAddress)]
          [Display(Name = "Email Address")]
          [Required(ErrorMessage = "You need to give us your email address.")]
          public string Email { get; set; }


     }
}