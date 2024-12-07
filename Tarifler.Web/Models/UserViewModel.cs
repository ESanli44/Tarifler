using System.ComponentModel.DataAnnotations;

namespace Tarifler.Web.Models
{
    public class UserViewModel
    {
            [Required]
            [Display(Name = "İsim")]
            public string? FirstName { get; set; }
            [Required]
            [Display(Name = "Soy İsim")]
            public string? LastName { get; set; }
            [Required]
            [Display(Name = "Kullanıcı Adı")]
            public string? UserName { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string? UserEmail { get; set; }

            [Display(Name = "Telefon")]
            public string? UserPhone { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Parola")]
            public string? UserPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare(nameof(UserPassword), ErrorMessage = "Parolalar Eşleşmiyor...")]
            [Display(Name = "Parola Tekrar")]
            public string? ConfirmPassword { get; set; }

    }
}
