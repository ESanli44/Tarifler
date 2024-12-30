using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceStack;
using System.ComponentModel.DataAnnotations;
using Tarifler.Core.Entity;

namespace Tarifler.Web.Models
{
    public class SifreGuncelleViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="Zorunlu ALAN")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Zorunlu ALAN")]
        [DataType(DataType.Password)]
        [Compare(nameof(UserPassword), ErrorMessage = "Parolalar Eşleşmiyor...")]
        [Display(Name = "Parola Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
