using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class Begeni
    {
        public int BegeniId { get; set; }
        public bool Begen { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? YemekTarifId { get; set; }
        public YemekTarif YemekTarif { get; set; }
    }
}
