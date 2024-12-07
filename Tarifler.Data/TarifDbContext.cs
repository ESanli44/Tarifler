using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tarifler.Core.Entity;

namespace Tarifler.Data
{
    public class TarifDbContext : DbContext
    {
        public DbSet<User> Kullanicilar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<YemekTarif> YemekTarifleri { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Yorum> Yorumlar{ get; set; }
        public DbSet<Begeni> Begeniler { get; set; }
        public DbSet<Mesaj> Mesajlar { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =DESKTOP-2Q9D56U\SQLEXPRESS;
                                        Database=TariflerDb; 
                                        Trusted_Connection=True; 
                                        TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AppUserConfiguration()); -- tabloları Tek tek almak yerine alttaki kod ile hepsini çekeriz

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


    }
}
