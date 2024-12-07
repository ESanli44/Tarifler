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
    internal class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(new List<Kategori>
            {
                new(){ KategoriId=1, KategoriAdi="Ana Yemek", KategoriAciklama="Ana Yemekler" },
                new(){ KategoriId=2, KategoriAdi="Ara Sıcak", KategoriAciklama="Ara Sıcaklar" },
                new(){ KategoriId=3, KategoriAdi="Başlangıç", KategoriAciklama="Başlangıçlar" },
                new(){ KategoriId=4, KategoriAdi="Tatlı", KategoriAciklama="Tatlılar" }
            });
        }
    }
}
