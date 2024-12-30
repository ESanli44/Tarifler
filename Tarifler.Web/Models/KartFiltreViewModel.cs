namespace Tarifler.Web.Models
{
    public class KartFiltreViewModel
    {
        public string? Arama { get; set; }
        public int? Kategori { get; set; }
        public int? PageNumber { get; set; } = 1; 
        public string? isim { get; set; }
    }
}
