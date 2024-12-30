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
                new (){ TurId=5, TurAdi="Çorba", TurAciklama="Çorba Yemekleri" },
                new (){ TurId=6, TurAdi="Salata", TurAciklama="Salata Çeşitleri" },
                new (){ TurId=7, TurAdi="Meze", TurAciklama="Meze Çeşitleri" },
                new (){ TurId=8, TurAdi="Pilav", TurAciklama="Pilav Çeşitleri" },
                new (){ TurId=9, TurAdi="Hmaur İşi", TurAciklama="Hamur İşi Yemekler" },
                new (){ TurId=10, TurAdi="Bakliyat", TurAciklama="Bakliyat Yemekleri" },
                new (){ TurId=11, TurAdi="Şerbetli Tatlılar", TurAciklama="Şerbetli Tatlılar" },
                new (){ TurId=12, TurAdi="Pasta", TurAciklama="Pasta Çeşitleri" },
            });
        }
    }
}
