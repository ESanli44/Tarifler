using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Tarifler.Web.Models
{
    public class BilgilerimViewModel
    {
        public int UserId { get; set; }
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
        public string? UserPassword { get; set; }
    }
}
