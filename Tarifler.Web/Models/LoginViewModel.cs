using System.ComponentModel.DataAnnotations;

namespace Tarifler.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? UserPassword { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
