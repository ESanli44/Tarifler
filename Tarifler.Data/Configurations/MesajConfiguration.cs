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
    internal class MesajConfiguration : IEntityTypeConfiguration<Mesaj>
    {
        public void Configure(EntityTypeBuilder<Mesaj> builder)
        {
            builder.HasData(new List<Mesaj>
            {
                new() { MesajId=1, Durum=false, Email="Email@gmail.com", MesajAciklama="Yazar Kadrosuna girmek istiyorum.",
                    Name="Basri", Tarih=DateTime.Now },

                new() { MesajId=2, Durum=false, Email="Tarkan@gmail.com", MesajAciklama="Sebze Yemek Sayisi Çok Az.",
                    Name="Ayşe", Tarih=DateTime.Now },

                new() { MesajId=3, Durum=false, Email="Merve@gmail.com", MesajAciklama="Yöresel Yemekler Bölümünde hata var..",
                    Name="Merve", Tarih=DateTime.Now },
            });
        }
    }
}
