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
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(new List<Slider>
            {
                new(){ SliderId=1, Baslik="Nefis Yemekler Bu Sitede", Aciklama="Uzman Aşçılar Sizin İçin Hazırladı.", 
                    Resim="wright-brand-bacon-varvj5jjtzc-unsplash.jpg",
                Icerik="Nefis Yemekler: Her Damağa Hitap Eden Efsane Lezzetler!\r\n\r\nYemek sitemizde, her öğün için sizi bekleyen nefis " +
                "tariflerle dolu bir dünya sunuyoruz. Her biri, taptaze malzemeler ve özenle seçilmiş tariflerle hazırlanmış, mutfağınızda" +
                " harikalar yaratmanız için ilham veriyor. Gerek geleneksel lezzetler, gerekse modern dokunuşlarla zenginleştirilmiş yemekler," +
                " sofralarınıza sadece doyuruculuk değil, aynı zamanda birer lezzet şöleni katacak.\r\n\r\nAşçılarımız, yılların deneyimini " +
                "ve mutfak sanatındaki ustalıklarını her tarifte ortaya koyuyor. Mutfakta geçirdiğimiz her an, size en lezzetli ve keyifli yemek " +
                "deneyimlerini sunma amacımızla şekilleniyor. İster sağlıklı, ister zengin tatlar arayanlar için, tüm damak zevklerine hitap eden" +
                " tariflerimizle karşınızdayız.\r\n\r\nKlasik tatlardan, dünyanın dört bir köşesinden gelen özel yemeklere kadar geniş bir " +
                "yelpazede sunulan nefis yemeklerimiz, sadece gözlere değil, aynı zamanda ruhunuza da hitap edecek. Mutfaklarınızda, en özel" +
                " anları paylaşmak ve sevdiklerinizle birlikte keyifli sofralar kurmak için ihtiyaç duyduğunuz her tarife buradan ulaşabilirsiniz." +
                "\r\n\r\nBundan daha fazlası için, sitemizdeki nefis yemek tariflerine göz atmayı unutmayın. Lezzetli bir keşif yapmak için" +
                " hemen başlayın ve yemeklerinizi en unutulmaz hale getirin!\r\n\r\n"},

                new(){ SliderId=2, Baslik="Hamburger Çeşitleri", Aciklama="Uzman Aşçılar Sizin İçin Hazırladı", Resim="hamburger.jpg",
                Icerik="Hamburgerin Zirvesine Yolculuk: Usta Aşçılardan Efsane Tarifler!\r\n\r\nYemek sitemizde, hamburgerin en lezzetli " +
                "halini deneyimlemeye hazır olun! Usta aşçılarımız, klasik ve yaratıcı hamburger tarifleriyle mutfaklarınıza eşsiz bir tat " +
                "katıyor. Her biri, sadece lezzet değil, aynı zamanda özenli bir ustalıkla hazırlanmış hamburgerler sunmak için titizlikle " +
                "çalışıyor.\r\n\r\nAşçılarımız, hamburgerin geleneksel tariflerini bir adım daha öteye taşıyarak, malzeme seçiminden pişirme " +
                "tekniklerine kadar her detayı mükemmel hale getiriyor. Efsane köfteler, taze ve kaliteli malzemeler, özgün soslar ve ekler," +
                " hamburgeri adeta bir sanat eserine dönüştürüyor. Her lokmada, lezzetlerin dansı ve eşsiz uyumu sizi bekliyor.\r\n\r\n" +
                "Hamburgerlerimiz, yalnızca doyurucu değil, aynı zamanda her damak zevkine hitap eden, özgün kombinasyonlarla bezenmiş. " +
                "Dilerseniz klasik Amerikan tarzı bir hamburgerin keyfini çıkarabilir, dilerseniz deniz ürünleri veya vejetaryen seçeneklerle " +
                "farklı tatlar keşfedebilirsiniz. Aşçılarımız, her tarifte benzersiz bir dokunuşla hamburgeri yeniden keşfetmenizi sağlıyor." +
                "\r\n\r\nHer bir hamburger, aşçılarımızın mutfakta geçirdiği yılların bir yansıması olarak, sadece lezzet değil, aynı zamanda" +
                " bir deneyim sunuyor. Hamburgerin sadece bir yemek değil, bir tutkuyla hazırlandığını hissedeceksiniz.\r\n\r\nHamburgerin en " +
                "özel halini keşfetmek için hemen sitemize göz atın, aşçılarımızın eşsiz tarifleriyle damağınızda unutulmaz tatlar bırakın!"},

                new(){ SliderId=3, Baslik="Dünya Mutfağı", Aciklama="Uzman Aşçılar Sizin İçin Hazırladı", Resim="emy-xobyibymx20-unsplash.jpg", 
                Icerik="Dünya Mutfağının Zirve Aşçılarıyla Tanışın: Eşsiz Tarifler, Büyüleyici Lezzetler!\r\n\r\nYemek sitemizde, dünya mutfaklarının" +
                " en gözde lezzetlerini sizlerle buluşturuyoruz! Ancak bu lezzetleri öne çıkaran asıl unsurlar, her biri kendi alanında usta" +
                " olan aşçılarımızdır. Yalnızca geleneksel tarifleri değil, aynı zamanda modern dokunuşlarla da harmanlanmış özgün tariflerle" +
                " de karşınızdayız.\r\n\r\nAşçılarımız, mutfağın her köşesinde dünyaca ünlü mutfak kültürlerinden ilham alarak, her tarifte eşsiz bir" +
                " lezzet deneyimi sunuyor. İtalya’dan Fransa’ya, Japonya’dan Meksika’ya kadar uzanan geniş bir yelpazede, her bir yemek sadece bir tabak" +
                " değil, aynı zamanda bir kültür yolculuğudur.\r\n\r\nAşçılarımız, yıllar süren deneyimleri ve yaratıcı bakış açılarıyla her tarifi bir" +
                " sanat eserine dönüştürüyor. Bir yandan geleneksel tatları korurken, diğer yandan cesur ve yenilikçi malzemelerle tatları zenginleştiriyorlar." +
                " Onların ellerinden çıkan her tarif, dünyadaki farklı mutfaklardan sadece lezzetleri değil, aynı zamanda o kültürün ruhunu da sofralarınıza " +
                "taşıyor.\r\n\r\nYemeklerimiz, her detayda titizlikle hazırlanıyor ve dünya çapındaki mutfakları en otantik şekilde deneyimlemeniz için özenle " +
                "sunuluyor. Sadece bir yemek değil, bir keşif, bir deneyim vaat ediyoruz. Her bir tarif, aşçılarımızın tutkusu ve bilgi birikimiyle buluşuyor " +
                "ve sofralarınızı unutulmaz kılıyor.\r\n\r\nSiz de dünya mutfaklarının büyüsüne kapılmak ve aşçılarımızın ustalıklarını keşfetmek istiyorsanız," +
                " sitemize göz atmayı unutmayın. Lezzet dolu bir yolculuğa çıkmaya hazır olun!"}
            });
        }
    }
}
