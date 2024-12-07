using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifler.Core.Entity;

namespace Tarifler.Data.Configurations
{
    internal class TurConfiguration : IEntityTypeConfiguration<Tur>
    {
        public void Configure(EntityTypeBuilder<Tur> builder)
        {
            builder.HasData(new List<Tur>
            {
                new (){ TurId=1, TurAdi="Et", TurAciklama="Et Yemekleri" },
                new (){ TurId=2, TurAdi="Balık", TurAciklama="Balık Yemekleri" },
                new (){ TurId=3, TurAdi="Tavuk", TurAciklama="Tavuk Yemekleri" },
                new (){ TurId=4, TurAdi="Sebze", TurAciklama="Sebze Yemekleri" },
                new (){ TurId=5, TurAdi="Çorba", TurAciklama="Çorba Yemekleri" }
            });
        }
    }
}
