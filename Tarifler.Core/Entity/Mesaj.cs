using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class Mesaj
    {
        public int MesajId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MesajAciklama { get; set; }       
        public bool Durum { get; set; }
        public DateTime? Tarih { get; set; }
    }
}