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
                new(){ TarifId=1, Baslik="İmam bayıldı", Malzeme="Tuz, Patlıcan, Lıyma, Domatez",
                    TarifAciklama="Patlıcanları alacalı soyarak yarım saat kadar tuzlu suda bekletin.\r\n" +
                    "İç harcı için soğanları piyazlık doğrayın, 2-3 yemek kaşığı sıvı yağ ile tavaya alın ve " +
                    "kavurmaya başlayın.\r\n5 dakika kadar soğanlar kavrulduktan sonra küçük doğranmış biberleri ve" +
                    " sarımsakları ilave edin, bir süre daha kavurun.\r\nBiberler diriliğini kaybedince küçük küçük " +
                    "doğranmış domates, baharatlar ve tuzu da ekleyerek domatesler suyunu biraz çekene kadar kavurmaya " +
                    "devam edin.\r\nİnce kıyılmış maydanozu ekleyerek ocaktan alın.\r\nTuzunu akıtıp, havlu kağıt ile " +
                    "kuruladığımız patlıcanları bol sıvı yağda çevirerek kızartın.\r\nKızaran patlıcanların yağının " +
                    "fazlasını alması için havlu kağıda alın.\r\nFazla yağı süzüldükten sonra fırın kabına aldığınız" +
                    " patlıcanların üzerini boydan çizgi şeklinde kesin. İçlerini dikkatli bir şekilde açın.\r\nİçlerine" +
                    " hazırladığınız iç harcından doldurun.\r\nSüslemek için üzerine çeri domatesler yerleştirin ve son " +
                    "olarak sıcak suda çözdürdüğünüz salçayı yemeğin üzerine gezdirin.\r\nHazır olan imambayıldıları önceden" +
                    " 190 derece ısıtılmış fırında 40 dakika pişirin.\r\nSürenin sonunda ince kıyılmış maydanozla süsleyerek " +
                    "servis edin. Afiyet olsun!",
                    Sure=15, kisiSayisi="4-6", IsActive=true, TurId=4, KategoriId=1, UserId=1, Resim="bayildi.webp",
                    Aciklama="Tek başına bir kültürdür Türk mutfağı. Neredeyse tüm mutfakların muadillerini bünyesinde barındırır. " +
                    "Üzerinde bulunduğu toprakların tarihçesinden dolayı üç kıta, onlarca farklı kültürden etkilenmiştir." +
                    " Şerbet bulsa tatlıya döker, süt bulsa tatlı yapar. Saray mutfağı diye bir başlı başına bir külliyatı vardır. " +
                    "Hamur işlerinde kimse eline su dökemez. Pilavı, Asyalılar kadar sever. Kıyma bulsa köfte yapar, et bulsa içine " +
                    "su katar. Güzeldir, samimidir, bereketlidir, orijinaldir."},

                new(){ TarifId=2, Baslik="Kebap", Malzeme="Tuz, Kıyma, Toz Biber, Sarımsak",
                    TarifAciklama="Öncelikle kıymamızı derince bir kaba alalım üzerine rendelenmiş kuru soğan ve sarımsaklarımızı " +
                    "katalım sonrasında baharat ve tuzunu da katıp iyice yoğuralım.\r\nBuzdolabında en az yarım saat dinlendirelim." +
                    "\r\nDinlenen kıymamızdan mandalina dan biraz büyük parçalar koparalım.(benim yassı şişim yetmediği için ince " +
                    "şişlerden iki tanesini birleştirip taktım )\r\nKopardığımız kıymamızı tahta şişimize takıp elimizi ara ara suya" +
                    " batırarak şekil verelim.\r\nYapması çok zevkli. Bu şekilde bitirelim ve fırın tepsimize dizelim yanlarına domates" +
                    " ve biberlerimizi yerleştirelim.\r\n200 derecede ısıtılmış fırında kızarana dek pişirelim.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=1, KategoriId=1, UserId=2,  Resim="Kebap.jpg",
                    Aciklama="Kebap, Orta Doğu ve Akdeniz mutfaklarının en tanınmış yemeklerinden biridir. Kelime olarak \"kebap,\" Arapça \"kebāb\" " +
                    "kelimesinden türemiş olup, pişmiş et anlamına gelir. Tarihsel olarak, kebaplar antik Mezopotamya, Pers, ve Osmanlı " +
                    "İmparatorluğu gibi medeniyetlerde önemli bir yer tutmuştur. Kebapların tarihi, binlerce yıl öncesine kadar dayanır ve" +
                    " farklı kültürlerin etkisiyle çeşitli şekillerde gelişmiştir."},

                new(){ TarifId=3, Baslik="Ezme Salata", Malzeme="Domates, Salatalık, Maydanoz, Tuz",
                    TarifAciklama="Sofralarınızda özellikle de et yemeklerinin yanında harika olacaktır😍 kesinlikle kaydedin ve yapın diyorum😋 " +
                    "Hem çok pratik bir şekilde hazırlanıyor yemelere doyum olmuyor. Ekmeği bandırmak bile büyük keyif veriyor öyle lezzetli " +
                    "öyle lezzetli💕😋\r\n\r\nDomatesler, biberler, soğan, maydanoz, salatalık, ve sarımsak hepsi rondoda çokta ince olmayacak" +
                    " şekilde çekilir. Küçük küçük doğrayarak yada rendeleyerek de yapabilirsiniz ama bu şekilde tavsiye ederim 5 dakikanızı " +
                    "alıyor ve lezzetleri birbirine güzelce geçiyor😍\r\nDerince bir kaba alınır. Üzerine salça, zeytinyağı, tuz, karabiber," +
                    " pul biber ve sirke eklenip kaşıkla iyice karıştırılır. İşte bu kadar✔️\r\nBir kavanoza koyup buz dolabında 2 haftaya " +
                    "kadar muhafaza edebilirsiniz.\r\nTariflerimi kaçırmamak için profilimdeki linkte Youtube kanalıma abone olmayı " +
                    "unutmayın👆🏻❤️🤗Afiyetle🤗",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=6, KategoriId=3, UserId=2, Resim="ezme-salata.webp",
                    Aciklama="Zeytinyağı, taze sıkılmış limon suyu, bol nar ekşisi, biber ve domates ile yemeklerin en güzel yancısı olan ezme;" +
                    " içerisine acı biber veya acı pul biber ekleyerek hazırlayabileceğiniz bir tarif."},

                new(){ TarifId=4, Baslik="Humus", Malzeme="Nohut, Tahin, Tuz, Buz",
                    TarifAciklama="İlk olarak haşlanmış nohutların kabuklarını elimizle soyalım.\r\nArdından nohutlarımızı rondoya alalım ve üzerine" +
                    " limon suyu, tahin, sarımsak, kimyon ve tuzu ekleyerek karıştıralım.\r\nTüm malzemeler birbiri ile özdeşleştikten sonra " +
                    "rondonun kapağını açalım. Eğer humusun istediğiniz kıvamda değilse su ilavesi yaparak ayarlayabilirsiniz.\r\nHazırladığımız" +
                    " humusu servis tabağına alalım ve kaşıkla şekillendirelim.\r\nArdından süslemek için ortasına haşlanmış nohut ve kırmızı biberle " +
                    "renklendirdiğimiz zeytinyağından gezdirelim.\r\nSon olarak sumak ve ince kıyılmış maydanoz serperek servis edelim." +
                    " Hazırlaması oldukça kolay mezelerden olan humusu deneyecek herkese şimdiden afiyet olsun!",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=7, KategoriId=3, UserId=3, Resim="humus.jpeg",
                    Aciklama="Humus, nohut ve tahine limon suyu, sarımsak, tuz, kimyon, kırmızı biber ve zeytinyağı eklenerek yapılan bir Orta Doğu mezesidir." +
                    " Houmous ve Hummus olarak da yazılıp okunur. Hummus Arapçada nohut anlamına gelmektedir."},

                new(){ TarifId=5, Baslik="Piriç Pilavı", Malzeme="Prinç, Şehriye, Tere Yağı",
                    TarifAciklama="Pirinçler bol su ile yıkanarak, ılık tuzlu suda yarım saat kadar bekletilir.\r\nBu süre sonunda, tuzlu suyu akıtılır " +
                    "ve pirinçler sudan geçirilerek, tüm suyu süzdürülür.\r\nPilav tenceresinde tereyağı eritilir, sıvı yağ da eklenerek üzerine arpa" +
                    " şehriyeler eklenir.\r\nŞehriyenin rengi dönene kadar kavrulur.\r\nPirinçler ilave edilerek, 2-3 dk daha kavrulur.\r\nÜzerine" +
                    " sıcak su eklenir ve tuzu ilave edilir.\r\nTencerenin kapağı kapatılarak, yüksek ateşte fazla suyu çekip pirinçler göz göz oluncaya" +
                    " kadar, yani pirinçlerin üzerinde su çekilip pirinçler göründüğünde kısık ateşe alın ve tamamen suyu çekene kadar pişirin. " +
                    "(Yazının devamında süreler ile ilgili detaylı açıklamayı bulabilirsiniz.)\r\nOcaktan aldıktan sonra, üzerine havlu kağıt koyarak " +
                    "kapağını tekrar kapatın ve demlenmesini bekleyin.\r\nPilavı güzelce karıştırdıktan sonra servis yapabilirsiniz.\r\nNot:" +
                    " Pilav yaparken su oranı 1’e 1,5 olarak ayarlıyorum. Yani 1 ölçü pirinç için, aynı ölçü kabı ile 1,5 kap su ekleyin. " +
                    "1 su bardağı pirinç, 3-4 kişi için yeterlidir.\r\n\r\nAfiyet olsun.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=8, KategoriId=2, UserId=3, Resim ="pilav.webp",
                    Aciklama="Tane tane pirinç pilavının sırrı, öncelikle pirincin kaliteli ve doğru yöntemler ile yıkanmış olmasından geçer. Pirinç" +
                    " pilavı tarifi tane tane olması için adımları doğru uygulamanız gerekir. Pirincin yıkanması sırasında nişastanın bir kısmı suya " +
                    "geçeceği için, pirincin nişasta oranı düşülerek yıkanması oldukça önem arz eder."},

                new(){ TarifId=6, Baslik="Levrek", Malzeme="Levrek, Tuz, Biber, Zetyin Yağı",
                    TarifAciklama=" Levrekleri temizletip yıkayalım.\r\n Fırın tepsisine yağlı kağıt sererek levrekleri üzerine yerleştirelim.\r\n" +
                    " Balıkların içine ve üzerine azar azar zeytinyağı gezdirelim. Tuz ve karabiber serpelim.\r\n Soğanları, domatesi ve limonu " +
                    "dilimleyerek balıkların içine yerleştirip fırına sürelim.\r\n 160 derecede 45-50 dakika kadar pişirelim.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=2, KategoriId=1, UserId=2, Resim="levrek.webp",
                    Aciklama="Eti çok lezzetli olan levrek balığı, vitamin ve mineral bakımından çok zengin bir balıktır. " +
                    "Omega 3 ve Omega 6 yağ asitleri içerir. İçerisinde A, B1, B2, B3, B5, B6, B12, D ve E vitaminlerinin yanı sıra iyot, çinko, " +
                    "potasyum, selenyum, magnezyum, demir, kalsiyum ve bolca fosfor bulunur."},

                new(){ TarifId=7, Baslik="Tavuk Sote", Malzeme="Tavuk, Yağ, Biber, Domates, Mantar",
                    TarifAciklama="Öncelikle tavuk ve mantarı minik minik doğruyoruz, biberleri dilerseniz julyen şekilde dilerseniz minik doğrayabilirsiniz." +
                    "\r\nSarımsağımızı da rendeliyoruz bir köşede bekletiyoruz.\r\nYapışmaz tavamızı kızdırıp tavuklarımızı atıyoruz.\r\nBeyazlaşınca " +
                    "mantarları ekliyoruz.\r\nMantarlar suyunu salıp çekince biberleri ve sarımsağı ekliyoruz.\r\nBiraz bu şekilde kavurup tereyağımızı " +
                    "ekliyoruz.\r\nBiberler hafif ölmeye yakın salçayı 1 bardak sıcak suyla açıp ekliyoruz (yanına makarna yapıyorsanız suyuyla salçayı " +
                    "açıp ekleyebilirsiniz)\r\nBaharatlarımızı da ekleyerek biraz kavuruyoruz, ardından iyice özdeşleşmesi için barbekü sosumuzu damak " +
                    "tadımıza göre az veya çok ekliyoruz (ben calve marka bbq kullandım)\r\nGüzelce pişmeye bırakıyoruz.\r\nPişmeye yakın susam ve " +
                    "mısıra ekleyip 5 dk kadar pişiriyoruz ve sotemiz hazır oluyor😍😍\r\nBen yanına kekikli makarna ve göbek salata tercih ettim çok " +
                    "yakışıyor 😌 deneyecek arkadaşlara şimdiden afiyet olsun🌸💕.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=3, KategoriId=1, UserId=1, Resim="tavuk-sote.webp",
                    Aciklama="Tavuk dünyasında yediğiniz barbekü soslu dan farksız yapımı basit ve çok lezzetli bir tarifle geldim 😋"},

                new(){ TarifId=8, Baslik="Analı Kızlı", Malzeme="Bulgur, Kıyma, Soğan, Maydonoz, Tuz", 
                    Aciklama="Orta büyüklükte 1 porsiyon analı kızlı köfte yaklaşık olarak 274 kaloriye denk gelmektedir." +
                    "\r\n--\r\n\r\nNefis Yemek Tarifleri WhatsApp kanalı açıldı, hemen siz de katılın.\r\n\r\n5 milyon'dan " +
                    "fazla kişinin takip ettiği Youtube kanalımızda videolu tariflerimizi bulabilirsiniz.\r\n\r\n15 milyondan fazla " +
                    "kişinin indirdiği Nefis Yemek Tarifleri uygulaması ile 850.000'den fazla denenmiş tarif her zaman yanınızda. " +
                    "Hemen siz de indirin.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=1, KategoriId=5, UserId=1, Resim ="anali-kizli-yemegi.jpg",
                    TarifAciklama="Bir gün önceden iç harcımızı hazırlamakta fayda var, bunun için yemeklik doğradığımız soğanlarımızı yağla beraber kavurup \" +\r\n " +
                    "\"kıymamızı ekliyoruz.\\r\\nKıyma suyunu çekince baharatlarını da ekleyip soğuyunca buzdolabına kaldırıyoruz.\\r\\nBulgurumuzu güzelce \" +\r\n" +
                    "\"yıkayıp yoğurma kabına alıyoruz.\\r\\nKıymamızı,  tuzunu irmiğini ekleyip arada su ekleyerek içli köfte açabileceğimiz kıvama gelene \" +\r\n" +
                    "\"kadar yaklaşık 20 dakika yoğuruyoruz.\\r\\nHamurumuzun bir kısmı ile hazırladığımız iç harcı kullanarak küçük içli köfteler yapıyoruz \" +\r\n" +
                    "\"(bunlar köftemizin anaları) kalan hamurumuzla küçük yuvarlak köfteler yapıyoruz (bunlar köftemizin kızları)\\r\\nDaha sonra geniş bir \" +\r\n" +
                    "\"çorba tenceresine biraz sıvı yağ ekleyip yemeklik doğradığımız soğanı kavuruyoruz.\\r\\nSalçamızı ve baharatlarımızı da ekleyip \" +\r\n" +
                    "\"üstünü geçecek kadar sıcak su ve nohutlarımızı ekliyoruz.\\r\\nSu kaynayınca köftelerimizi özenle suyun içine atıyoruz.\\r\\nBir iki \" +\r\n" +
                    "\"taşım kaynayınca köftemiz servise hazırdır. Afiyet olsun. :)"},

                new(){ TarifId=9, Baslik="Yaş Pasta", Malzeme="Un, Yumurta, Süt, Yağ, Çikolata", 
                    Aciklama="Borcamda kolaylıkla hazırlayabileceğiniz yaş pastayı aratmayacak sunumuyla lezzetiyle çok porsiyonlu oluşuyla bu pasta anlatılmaz yaşanır " +
                    "cinsten diyorum💯😋👌🏻tarifin detaylı yapılış videosuna ve diğer videolu tariflerime profilimdeki linkten ya da youtube arama bölümüne esin akan " +
                    "tarifleri yazarak ulaşabilirsiniz.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=12, KategoriId=6, UserId=2, Resim="yas-pasta.webp",
                    TarifAciklama="İlk olarak pandispanya için; yumurtaların sarıları ile beyazlarını ayıralım.\r\nYumurta sarılarını, şeker ile krema " +
                    "kıvamına gelene kadar 6-7 dakika çırpın.\r\nDaha sonra su, un, kabartma tozu ve vanilyayı da ekleyerek, tekrar karıştıralım.\r\nAyrı " +
                    "bir kapta, yumurta akı ve tuzu kar gibi oluncaya kadar çırpalım.\r\nHazırladığımız yumurta aklarını, kek hamuruna ilave edelim. " +
                    "Spatula yardımı ile köpükleri söndürmemeye çalışarak, aynı yönde karıştıralım. Bu bölümü, videoda detaylı bir şekilde izleyebilirsiniz." +
                    "\r\nPandispanyamızın hamuru hazır. Pişirmeye geçebiliriz. 18 cm çapında, 2 adet kelepçeli kalıp kullandım. Kelepçeli kalıbımızın" +
                    " tabanını, pişirme kağıdı ile kaplayalım.\r\nKek hamurumuzu iki parçaya bölerek, kalıplara dökelim.\r\nÖnceden ısıttığımız " +
                    "175 derece fırında, yaklaşık 40 dk pişirelim. Kürdan testi yaparak, pandispanyamızı fırından çıkartalım. Pişme süresi fırından " +
                    "fırına değişebilir, bu nedenle kontrol ederek fırından almanızı öneririm.\r\nPişen kekimizi fırından aldıktan sonra, üzerlerine " +
                    "temiz bir örtelim ve soğumaya bırakalım.\r\nİyice soğuyan keklerimizi, vaktiniz var ise streç film ile sararak bir gece buzdolabında" +
                    " dinlendirebilirsiniz. Vaktiniz yok ise muhallebiyi pişirmeye geçebiliriz :)\r\nMuhallebisi için; süt, un, nişasta ve şekeri " +
                    "güzelce çırpalım. Koyulaşıp, göz göz oluncaya kadar karıştırarak pişirelim.\r\nOcaktan aldığımız kremaya, tereyağını ve vanilyayı" +
                    " ekleyerek karıştıralım. Muhallebimizi soğumaya bırakalım.\r\nSoğuyan kremaya, toz krem şantiyi ekleyerek güzelce çırpalım.\r\nKekleri" +
                    " kalıptan çıkartarak, 2 kat olacak şekilde keselim.\r\nAralarına krema sürerek, katları üst üste yerleştirelim.\r\nPastamızı " +
                    "bir gece dinlenmeye bırakalım.\r\nÜzerini kaplamak için sıvı kremaya, pudra şekerini ekleyerek güzelce çırpalım. Buzdolabına" +
                    " kaldıralım.\r\nSon olarak, pastamızı krema ile güzelce kaplayalım. Aslında bu bölüm tamamen sizin isteğinize kalmış. " +
                    "Farklı bir kaplama da kullanabilirsiniz.\r\nKremanın üzerini, Hindistan cevizi ile kaplayalım.\r\nÜzerini, meyveler ile süsleyerek " +
                    "servis yapabilirsiniz."},

                new(){ TarifId=10, Baslik="Fıstıklı Burma", Malzeme="Fsıtık, Un, Yağ, Şeker", 
                    Aciklama="Dokusu kıvamı lezzeti harika olan tatlı tarifi bırakıyorum buraya.\r\n\r\nSe,vdiklerinizle paylaşmayı unutmayın.",
                    Sure=10,kisiSayisi="4-6", IsActive=true, TurId=11, KategoriId=4, UserId=3, Resim="burma.jpg",
                    TarifAciklama="Öncelikle şerbeti hazırlayın. Şerbetin soğuk olması gerekiyor. Ne kadar soğuk olursa, o kadar çıtır olur.\r\nHazır " +
                    "yufkaları, iki kat iki kat olacak şekilde ayırın.\r\nÜstlerine sıvı yağ sürün, isteyen sadece tereyağı ya da hem tereyağı hem " +
                    "sıvı yağ karıştırabilir. Bana ağır geldiği için, ben sadece sıvı yağ kullandım.\r\nSıvı yağ sürülmüş yufkalara çekilmiş fıstık " +
                    "içini koyup, oklavaya sarın.\r\nOklavanın her iki tarafını büzerek, oklavadan çıkarın. Yağlanmış fırın tepsisine dizin.\r\n" +
                    "En son üstlerine sıvı yağ sürüp, 180 derece ısınmış fırında 20 dakika pişirin.\r\nFırının ilk sıcaklığı geçince, buz gibi " +
                    "şerbeti üstüne dökün. Şerbetle tatlının buluştuğu an, çıkan ses işte beni benden alıyor :)\r\nFıstıkla süsleyin ve servis edin."},
            });
        }
    }
}
