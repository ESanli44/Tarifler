using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public bool Liked { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? TarifId { get; set; }
        public YemekTarif YemekTarif { get; set; }
    }
}
