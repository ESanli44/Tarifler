using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifler.Core.Entity;

namespace Tarifler.Data.Configurations
{
    internal class TarifConfiguration : IEntityTypeConfiguration<YemekTarif>
    {
        public void Configure(EntityTypeBuilder<YemekTarif> builder) 
        {
            builder.HasData(new List<YemekTarif>
            {
                new(){ TarifId=1, Baslik="İmam bayıldı", Malzeme="Tuz, Patlıcan, Lıyma, Domatez",Aciklama="Aciklama",
                    Sure=15, kisiSayisi="4-6", IsActive=true, TurId=4, KategoriId=1, UserId=1, TarifAciklama="Tarif"},

                new(){ TarifId=2, Baslik="Kebap", Malzeme="Tuz, Kıyma, Biber", Aciklama="Aciklama",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=1, KategoriId=1, UserId=2, TarifAciklama="Tarif"},
            });
        }
    }
}
