using System.ComponentModel.DataAnnotations;

namespace FindABand.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail address is required")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
