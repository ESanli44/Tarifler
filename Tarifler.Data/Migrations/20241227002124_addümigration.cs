using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tarifler.Data.Migrations
{
    /// <inheritdoc />
    public partial class addümigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsGuest = table.Column<bool>(type: "bit", nullable: false),
                    IsMember = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlar",
                columns: table => new
                {
                    MesajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesajAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlar", x => x.MesajId);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderId);
                });

            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    TurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.TurId);
                });

            migrationBuilder.CreateTable(
                name: "YemekTarifleri",
                columns: table => new
                {
                    TarifId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false),
                    Malzeme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kisiSayisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarifAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    TurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YemekTarifleri", x => x.TarifId);
                    table.ForeignKey(
                        name: "FK_YemekTarifleri_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_YemekTarifleri_Kullanicilar_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_YemekTarifleri_Turler_TurId",
                        column: x => x.TurId,
                        principalTable: "Turler",
                        principalColumn: "TurId");
                });

            migrationBuilder.CreateTable(
                name: "Begeniler",
                columns: table => new
                {
                    BegeniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begen = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    YemekTarifId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Begeniler", x => x.BegeniId);
                    table.ForeignKey(
                        name: "FK_Begeniler_Kullanicilar_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Begeniler_YemekTarifleri_YemekTarifId",
                        column: x => x.YemekTarifId,
                        principalTable: "YemekTarifleri",
                        principalColumn: "TarifId");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TarifId = table.Column<int>(type: "int", nullable: true),
                    YemekTarifTarifId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Like_Kullanicilar_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Like_YemekTarifleri_YemekTarifTarifId",
                        column: x => x.YemekTarifTarifId,
                        principalTable: "YemekTarifleri",
                        principalColumn: "TarifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayinTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    YemekTarifId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kullanicilar_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Yorumlar_YemekTarifleri_YemekTarifId",
                        column: x => x.YemekTarifId,
                        principalTable: "YemekTarifleri",
                        principalColumn: "TarifId");
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriId", "KategoriAciklama", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Ana Yemekler", "Ana Yemek" },
                    { 2, "Ara Sıcaklar", "Ara Sıcak" },
                    { 3, "Başlangıçlar", "Başlangıç" },
                    { 4, "Tatlılar", "Tatlı" },
                    { 5, "Yöresel Yemekler", "Yöresel" },
                    { 6, "Pastalar", "Pasta" }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "UserId", "FirstName", "IsActive", "IsAdmin", "IsGuest", "IsMember", "LastName", "UserEmail", "UserName", "UserPassword", "UserPhone" },
                values: new object[,]
                {
                    { 1, "Emrah", true, true, false, false, "Şanlı", "Esanli@gmail.com", "Esanli", "Emrah.123", "11111111111" },
                    { 2, "Aylin", true, false, false, true, "Şanlı", "Asanli@gmail.com", "Asanli", "Aylin.123", "11111111111" },
                    { 3, "Umay", true, false, false, true, "Şanlı", "Usanli@gmail.com", "Usanli", "Umay.123", "11111111111" },
                    { 4, "Zehra", true, false, true, false, "Şanlı", "Zsanli@gmail.com", "Zsanli", "Zehra.123", "11111111111" }
                });

            migrationBuilder.InsertData(
                table: "Mesajlar",
                columns: new[] { "MesajId", "Durum", "Email", "MesajAciklama", "Name", "Tarih" },
                values: new object[,]
                {
                    { 1, false, "Email@gmail.com", "Yazar Kadrosuna girmek istiyorum.", "Basri", new DateTime(2024, 12, 27, 2, 21, 21, 640, DateTimeKind.Local).AddTicks(6512) },
                    { 2, false, "Tarkan@gmail.com", "Sebze Yemek Sayisi Çok Az.", "Ayşe", new DateTime(2024, 12, 27, 2, 21, 21, 640, DateTimeKind.Local).AddTicks(6552) },
                    { 3, false, "Merve@gmail.com", "Yöresel Yemekler Bölümünde hata var..", "Merve", new DateTime(2024, 12, 27, 2, 21, 21, 640, DateTimeKind.Local).AddTicks(6557) }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "SliderId", "Aciklama", "Baslik", "Resim" },
                values: new object[,]
                {
                    { 1, "Uzman Aşçılar Sizin İçin Hazırladı.", "Nefis Yemekler Bu Sitede", "wright-brand-bacon-varvj5jjtzc-unsplash.jpg" },
                    { 2, "Uzman Aşçılar Sizin İçin Hazırladı", "Hmburger Çeşitleri", "hamburger.jpg" },
                    { 3, "Uzman Aşçılar Sizin İçin Hazırladı", "Dünya Mutfağı", "emy-xobyibymx20-unsplash.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Turler",
                columns: new[] { "TurId", "TurAciklama", "TurAdi" },
                values: new object[,]
                {
                    { 1, "Et Yemekleri", "Et" },
                    { 2, "Balık Yemekleri", "Balık" },
                    { 3, "Tavuk Yemekleri", "Tavuk" },
                    { 4, "Sebze Yemekleri", "Sebze" },
                    { 5, "Çorba Yemekleri", "Çorba" },
                    { 6, "Salata Çeşitleri", "Salata" },
                    { 7, "Meze Çeşitleri", "Meze" },
                    { 8, "Pilav Çeşitleri", "Pilav" },
                    { 9, "Hamur İşi Yemekler", "Hmaur İşi" },
                    { 10, "Bakliyat Yemekleri", "Bakliyat" },
                    { 11, "Şerbetli Tatlılar", "Şerbetli Tatlılar" },
                    { 12, "Pasta Çeşitleri", "Pasta" }
                });

            migrationBuilder.InsertData(
                table: "YemekTarifleri",
                columns: new[] { "TarifId", "Aciklama", "Baslik", "IsActive", "KategoriId", "Malzeme", "Resim", "Sure", "TarifAciklama", "TurId", "UserId", "kisiSayisi" },
                values: new object[,]
                {
                    { 1, "Tek başına bir kültürdür Türk mutfağı. Neredeyse tüm mutfakların muadillerini bünyesinde barındırır. Üzerinde bulunduğu toprakların tarihçesinden dolayı üç kıta, onlarca farklı kültürden etkilenmiştir. Şerbet bulsa tatlıya döker, süt bulsa tatlı yapar. Saray mutfağı diye bir başlı başına bir külliyatı vardır. Hamur işlerinde kimse eline su dökemez. Pilavı, Asyalılar kadar sever. Kıyma bulsa köfte yapar, et bulsa içine su katar. Güzeldir, samimidir, bereketlidir, orijinaldir.", "İmam bayıldı", true, 1, "Tuz, Patlıcan, Lıyma, Domatez", null, 15, "Patlıcanları alacalı soyarak yarım saat kadar tuzlu suda bekletin.\r\nİç harcı için soğanları piyazlık doğrayın, 2-3 yemek kaşığı sıvı yağ ile tavaya alın ve kavurmaya başlayın.\r\n5 dakika kadar soğanlar kavrulduktan sonra küçük doğranmış biberleri ve sarımsakları ilave edin, bir süre daha kavurun.\r\nBiberler diriliğini kaybedince küçük küçük doğranmış domates, baharatlar ve tuzu da ekleyerek domatesler suyunu biraz çekene kadar kavurmaya devam edin.\r\nİnce kıyılmış maydanozu ekleyerek ocaktan alın.\r\nTuzunu akıtıp, havlu kağıt ile kuruladığımız patlıcanları bol sıvı yağda çevirerek kızartın.\r\nKızaran patlıcanların yağının fazlasını alması için havlu kağıda alın.\r\nFazla yağı süzüldükten sonra fırın kabına aldığınız patlıcanların üzerini boydan çizgi şeklinde kesin. İçlerini dikkatli bir şekilde açın.\r\nİçlerine hazırladığınız iç harcından doldurun.\r\nSüslemek için üzerine çeri domatesler yerleştirin ve son olarak sıcak suda çözdürdüğünüz salçayı yemeğin üzerine gezdirin.\r\nHazır olan imambayıldıları önceden 190 derece ısıtılmış fırında 40 dakika pişirin.\r\nSürenin sonunda ince kıyılmış maydanozla süsleyerek servis edin. Afiyet olsun!", 4, 1, "4-6" },
                    { 2, "Kebap, Orta Doğu ve Akdeniz mutfaklarının en tanınmış yemeklerinden biridir. Kelime olarak \"kebap,\" Arapça \"kebāb\" kelimesinden türemiş olup, pişmiş et anlamına gelir. Tarihsel olarak, kebaplar antik Mezopotamya, Pers, ve Osmanlı İmparatorluğu gibi medeniyetlerde önemli bir yer tutmuştur. Kebapların tarihi, binlerce yıl öncesine kadar dayanır ve farklı kültürlerin etkisiyle çeşitli şekillerde gelişmiştir.", "Kebap", true, 1, "Tuz, Kıyma, Toz Biber, Sarımsak", null, 10, "Öncelikle kıymamızı derince bir kaba alalım üzerine rendelenmiş kuru soğan ve sarımsaklarımızı katalım sonrasında baharat ve tuzunu da katıp iyice yoğuralım.\r\nBuzdolabında en az yarım saat dinlendirelim.\r\nDinlenen kıymamızdan mandalina dan biraz büyük parçalar koparalım.(benim yassı şişim yetmediği için ince şişlerden iki tanesini birleştirip taktım )\r\nKopardığımız kıymamızı tahta şişimize takıp elimizi ara ara suya batırarak şekil verelim.\r\nYapması çok zevkli. Bu şekilde bitirelim ve fırın tepsimize dizelim yanlarına domates ve biberlerimizi yerleştirelim.\r\n200 derecede ısıtılmış fırında kızarana dek pişirelim.", 1, 2, "4-6" },
                    { 3, "Zeytinyağı, taze sıkılmış limon suyu, bol nar ekşisi, biber ve domates ile yemeklerin en güzel yancısı olan ezme; içerisine acı biber veya acı pul biber ekleyerek hazırlayabileceğiniz bir tarif.", "Ezme Salata", true, 3, "Domates, Salatalık, Maydanoz, Tuz", null, 10, "Sofralarınızda özellikle de et yemeklerinin yanında harika olacaktır😍 kesinlikle kaydedin ve yapın diyorum😋 Hem çok pratik bir şekilde hazırlanıyor yemelere doyum olmuyor. Ekmeği bandırmak bile büyük keyif veriyor öyle lezzetli öyle lezzetli💕😋\r\n\r\nDomatesler, biberler, soğan, maydanoz, salatalık, ve sarımsak hepsi rondoda çokta ince olmayacak şekilde çekilir. Küçük küçük doğrayarak yada rendeleyerek de yapabilirsiniz ama bu şekilde tavsiye ederim 5 dakikanızı alıyor ve lezzetleri birbirine güzelce geçiyor😍\r\nDerince bir kaba alınır. Üzerine salça, zeytinyağı, tuz, karabiber, pul biber ve sirke eklenip kaşıkla iyice karıştırılır. İşte bu kadar✔️\r\nBir kavanoza koyup buz dolabında 2 haftaya kadar muhafaza edebilirsiniz.\r\nTariflerimi kaçırmamak için profilimdeki linkte Youtube kanalıma abone olmayı unutmayın👆🏻❤️🤗Afiyetle🤗", 6, 2, "4-6" },
                    { 4, "Humus, nohut ve tahine limon suyu, sarımsak, tuz, kimyon, kırmızı biber ve zeytinyağı eklenerek yapılan bir Orta Doğu mezesidir. Houmous ve Hummus olarak da yazılıp okunur. Hummus Arapçada nohut anlamına gelmektedir.", "Humus", true, 3, "Nohut, Tahin, Tuz, Buz", null, 10, "İlk olarak haşlanmış nohutların kabuklarını elimizle soyalım.\r\nArdından nohutlarımızı rondoya alalım ve üzerine limon suyu, tahin, sarımsak, kimyon ve tuzu ekleyerek karıştıralım.\r\nTüm malzemeler birbiri ile özdeşleştikten sonra rondonun kapağını açalım. Eğer humusun istediğiniz kıvamda değilse su ilavesi yaparak ayarlayabilirsiniz.\r\nHazırladığımız humusu servis tabağına alalım ve kaşıkla şekillendirelim.\r\nArdından süslemek için ortasına haşlanmış nohut ve kırmızı biberle renklendirdiğimiz zeytinyağından gezdirelim.\r\nSon olarak sumak ve ince kıyılmış maydanoz serperek servis edelim. Hazırlaması oldukça kolay mezelerden olan humusu deneyecek herkese şimdiden afiyet olsun!", 7, 3, "4-6" },
                    { 5, "Tane tane pirinç pilavının sırrı, öncelikle pirincin kaliteli ve doğru yöntemler ile yıkanmış olmasından geçer. Pirinç pilavı tarifi tane tane olması için adımları doğru uygulamanız gerekir. Pirincin yıkanması sırasında nişastanın bir kısmı suya geçeceği için, pirincin nişasta oranı düşülerek yıkanması oldukça önem arz eder.", "Piriç Pilavı", true, 2, "Prinç, Şehriye, Tere Yağı", null, 10, "Pirinçler bol su ile yıkanarak, ılık tuzlu suda yarım saat kadar bekletilir.\r\nBu süre sonunda, tuzlu suyu akıtılır ve pirinçler sudan geçirilerek, tüm suyu süzdürülür.\r\nPilav tenceresinde tereyağı eritilir, sıvı yağ da eklenerek üzerine arpa şehriyeler eklenir.\r\nŞehriyenin rengi dönene kadar kavrulur.\r\nPirinçler ilave edilerek, 2-3 dk daha kavrulur.\r\nÜzerine sıcak su eklenir ve tuzu ilave edilir.\r\nTencerenin kapağı kapatılarak, yüksek ateşte fazla suyu çekip pirinçler göz göz oluncaya kadar, yani pirinçlerin üzerinde su çekilip pirinçler göründüğünde kısık ateşe alın ve tamamen suyu çekene kadar pişirin. (Yazının devamında süreler ile ilgili detaylı açıklamayı bulabilirsiniz.)\r\nOcaktan aldıktan sonra, üzerine havlu kağıt koyarak kapağını tekrar kapatın ve demlenmesini bekleyin.\r\nPilavı güzelce karıştırdıktan sonra servis yapabilirsiniz.\r\nNot: Pilav yaparken su oranı 1’e 1,5 olarak ayarlıyorum. Yani 1 ölçü pirinç için, aynı ölçü kabı ile 1,5 kap su ekleyin. 1 su bardağı pirinç, 3-4 kişi için yeterlidir.\r\n\r\nAfiyet olsun.", 8, 3, "4-6" },
                    { 6, "Eti çok lezzetli olan levrek balığı, vitamin ve mineral bakımından çok zengin bir balıktır. Omega 3 ve Omega 6 yağ asitleri içerir. İçerisinde A, B1, B2, B3, B5, B6, B12, D ve E vitaminlerinin yanı sıra iyot, çinko, potasyum, selenyum, magnezyum, demir, kalsiyum ve bolca fosfor bulunur.", "Levrek", true, 1, "Levrek, Tuz, Biber, Zetyin Yağı", null, 10, " Levrekleri temizletip yıkayalım.\r\n Fırın tepsisine yağlı kağıt sererek levrekleri üzerine yerleştirelim.\r\n Balıkların içine ve üzerine azar azar zeytinyağı gezdirelim. Tuz ve karabiber serpelim.\r\n Soğanları, domatesi ve limonu dilimleyerek balıkların içine yerleştirip fırına sürelim.\r\n 160 derecede 45-50 dakika kadar pişirelim.", 2, 2, "4-6" },
                    { 7, "Tavuk dünyasında yediğiniz barbekü soslu dan farksız yapımı basit ve çok lezzetli bir tarifle geldim 😋", "Tavuk Sote", true, 1, "Tavuk, Yağ, Biber, Domates, Mantar", null, 10, "Öncelikle tavuk ve mantarı minik minik doğruyoruz, biberleri dilerseniz julyen şekilde dilerseniz minik doğrayabilirsiniz.\r\nSarımsağımızı da rendeliyoruz bir köşede bekletiyoruz.\r\nYapışmaz tavamızı kızdırıp tavuklarımızı atıyoruz.\r\nBeyazlaşınca mantarları ekliyoruz.\r\nMantarlar suyunu salıp çekince biberleri ve sarımsağı ekliyoruz.\r\nBiraz bu şekilde kavurup tereyağımızı ekliyoruz.\r\nBiberler hafif ölmeye yakın salçayı 1 bardak sıcak suyla açıp ekliyoruz (yanına makarna yapıyorsanız suyuyla salçayı açıp ekleyebilirsiniz)\r\nBaharatlarımızı da ekleyerek biraz kavuruyoruz, ardından iyice özdeşleşmesi için barbekü sosumuzu damak tadımıza göre az veya çok ekliyoruz (ben calve marka bbq kullandım)\r\nGüzelce pişmeye bırakıyoruz.\r\nPişmeye yakın susam ve mısıra ekleyip 5 dk kadar pişiriyoruz ve sotemiz hazır oluyor😍😍\r\nBen yanına kekikli makarna ve göbek salata tercih ettim çok yakışıyor 😌 deneyecek arkadaşlara şimdiden afiyet olsun🌸💕.", 3, 1, "4-6" },
                    { 8, "Orta büyüklükte 1 porsiyon analı kızlı köfte yaklaşık olarak 274 kaloriye denk gelmektedir.\r\n--\r\n\r\nNefis Yemek Tarifleri WhatsApp kanalı açıldı, hemen siz de katılın.\r\n\r\n5 milyon'dan fazla kişinin takip ettiği Youtube kanalımızda videolu tariflerimizi bulabilirsiniz.\r\n\r\n15 milyondan fazla kişinin indirdiği Nefis Yemek Tarifleri uygulaması ile 850.000'den fazla denenmiş tarif her zaman yanınızda. Hemen siz de indirin.", "Analı Kızlı", true, 5, "Bulgur, Kıyma, Soğan, Maydonoz, Tuz", null, 10, "Bir gün önceden iç harcımızı hazırlamakta fayda var, bunun için yemeklik doğradığımız soğanlarımızı yağla beraber kavurup \" +\r\n \"kıymamızı ekliyoruz.\\r\\nKıyma suyunu çekince baharatlarını da ekleyip soğuyunca buzdolabına kaldırıyoruz.\\r\\nBulgurumuzu güzelce \" +\r\n\"yıkayıp yoğurma kabına alıyoruz.\\r\\nKıymamızı,  tuzunu irmiğini ekleyip arada su ekleyerek içli köfte açabileceğimiz kıvama gelene \" +\r\n\"kadar yaklaşık 20 dakika yoğuruyoruz.\\r\\nHamurumuzun bir kısmı ile hazırladığımız iç harcı kullanarak küçük içli köfteler yapıyoruz \" +\r\n\"(bunlar köftemizin anaları) kalan hamurumuzla küçük yuvarlak köfteler yapıyoruz (bunlar köftemizin kızları)\\r\\nDaha sonra geniş bir \" +\r\n\"çorba tenceresine biraz sıvı yağ ekleyip yemeklik doğradığımız soğanı kavuruyoruz.\\r\\nSalçamızı ve baharatlarımızı da ekleyip \" +\r\n\"üstünü geçecek kadar sıcak su ve nohutlarımızı ekliyoruz.\\r\\nSu kaynayınca köftelerimizi özenle suyun içine atıyoruz.\\r\\nBir iki \" +\r\n\"taşım kaynayınca köftemiz servise hazırdır. Afiyet olsun. :)", 1, 1, "4-6" },
                    { 9, "Borcamda kolaylıkla hazırlayabileceğiniz yaş pastayı aratmayacak sunumuyla lezzetiyle çok porsiyonlu oluşuyla bu pasta anlatılmaz yaşanır cinsten diyorum💯😋👌🏻tarifin detaylı yapılış videosuna ve diğer videolu tariflerime profilimdeki linkten ya da youtube arama bölümüne esin akan tarifleri yazarak ulaşabilirsiniz.", "Yaş Pasta", true, 6, "Un, Yumurta, Süt, Yağ, Çikolata", null, 10, "İlk olarak pandispanya için; yumurtaların sarıları ile beyazlarını ayıralım.\r\nYumurta sarılarını, şeker ile krema kıvamına gelene kadar 6-7 dakika çırpın.\r\nDaha sonra su, un, kabartma tozu ve vanilyayı da ekleyerek, tekrar karıştıralım.\r\nAyrı bir kapta, yumurta akı ve tuzu kar gibi oluncaya kadar çırpalım.\r\nHazırladığımız yumurta aklarını, kek hamuruna ilave edelim. Spatula yardımı ile köpükleri söndürmemeye çalışarak, aynı yönde karıştıralım. Bu bölümü, videoda detaylı bir şekilde izleyebilirsiniz.\r\nPandispanyamızın hamuru hazır. Pişirmeye geçebiliriz. 18 cm çapında, 2 adet kelepçeli kalıp kullandım. Kelepçeli kalıbımızın tabanını, pişirme kağıdı ile kaplayalım.\r\nKek hamurumuzu iki parçaya bölerek, kalıplara dökelim.\r\nÖnceden ısıttığımız 175 derece fırında, yaklaşık 40 dk pişirelim. Kürdan testi yaparak, pandispanyamızı fırından çıkartalım. Pişme süresi fırından fırına değişebilir, bu nedenle kontrol ederek fırından almanızı öneririm.\r\nPişen kekimizi fırından aldıktan sonra, üzerlerine temiz bir örtelim ve soğumaya bırakalım.\r\nİyice soğuyan keklerimizi, vaktiniz var ise streç film ile sararak bir gece buzdolabında dinlendirebilirsiniz. Vaktiniz yok ise muhallebiyi pişirmeye geçebiliriz :)\r\nMuhallebisi için; süt, un, nişasta ve şekeri güzelce çırpalım. Koyulaşıp, göz göz oluncaya kadar karıştırarak pişirelim.\r\nOcaktan aldığımız kremaya, tereyağını ve vanilyayı ekleyerek karıştıralım. Muhallebimizi soğumaya bırakalım.\r\nSoğuyan kremaya, toz krem şantiyi ekleyerek güzelce çırpalım.\r\nKekleri kalıptan çıkartarak, 2 kat olacak şekilde keselim.\r\nAralarına krema sürerek, katları üst üste yerleştirelim.\r\nPastamızı bir gece dinlenmeye bırakalım.\r\nÜzerini kaplamak için sıvı kremaya, pudra şekerini ekleyerek güzelce çırpalım. Buzdolabına kaldıralım.\r\nSon olarak, pastamızı krema ile güzelce kaplayalım. Aslında bu bölüm tamamen sizin isteğinize kalmış. Farklı bir kaplama da kullanabilirsiniz.\r\nKremanın üzerini, Hindistan cevizi ile kaplayalım.\r\nÜzerini, meyveler ile süsleyerek servis yapabilirsiniz.", 12, 2, "4-6" },
                    { 10, "Dokusu kıvamı lezzeti harika olan tatlı tarifi bırakıyorum buraya.\r\n\r\nSevdiklerinizle paylaşmayı unutmayın.", "Fıstıklı Burma", true, 4, "Fsıtık, Un, Yağ, Şeker", null, 10, "Öncelikle şerbeti hazırlayın. Şerbetin soğuk olması gerekiyor. Ne kadar soğuk olursa, o kadar çıtır olur.\r\nHazır yufkaları, iki kat iki kat olacak şekilde ayırın.\r\nÜstlerine sıvı yağ sürün, isteyen sadece tereyağı ya da hem tereyağı hem sıvı yağ karıştırabilir. Bana ağır geldiği için, ben sadece sıvı yağ kullandım.\r\nSıvı yağ sürülmüş yufkalara çekilmiş fıstık içini koyup, oklavaya sarın.\r\nOklavanın her iki tarafını büzerek, oklavadan çıkarın. Yağlanmış fırın tepsisine dizin.\r\nEn son üstlerine sıvı yağ sürüp, 180 derece ısınmış fırında 20 dakika pişirin.\r\nFırının ilk sıcaklığı geçince, buz gibi şerbeti üstüne dökün. Şerbetle tatlının buluştuğu an, çıkan ses işte beni benden alıyor :)\r\nFıstıkla süsleyin ve servis edin.", 11, 3, "4-6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Begeniler_UserId",
                table: "Begeniler",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Begeniler_YemekTarifId",
                table: "Begeniler",
                column: "YemekTarifId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_YemekTarifTarifId",
                table: "Like",
                column: "YemekTarifTarifId");

            migrationBuilder.CreateIndex(
                name: "IX_YemekTarifleri_KategoriId",
                table: "YemekTarifleri",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_YemekTarifleri_TurId",
                table: "YemekTarifleri",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_YemekTarifleri_UserId",
                table: "YemekTarifleri",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_UserId",
                table: "Yorumlar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_YemekTarifId",
                table: "Yorumlar",
                column: "YemekTarifId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Begeniler");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Mesajlar");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "YemekTarifleri");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Turler");
        }
    }
}
