using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarifler.Web.Models
{
    public class IletisimViewModel
    {
        public int MesajId { get; set; }

        [Required(ErrorMessage ="Zorunlu Alan")]
        [Display(Name ="Isminiz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Mesajınız")]
        public string MesajAciklama { get; set; }

        [DefaultValue(false)]
        public bool? Durum { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Tarih { get; set; } = DateTime.Now;
    }
}
