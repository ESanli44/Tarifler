using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tarifler.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitiaCreate : Migration
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
                    { 4, "Tatlılar", "Tatlı" }
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
                table: "Turler",
                columns: new[] { "TurId", "TurAciklama", "TurAdi" },
                values: new object[,]
                {
                    { 1, "Et Yemekleri", "Et" },
                    { 2, "Balık Yemekleri", "Balık" },
                    { 3, "Tavuk Yemekleri", "Tavuk" },
                    { 4, "Sebze Yemekleri", "Sebze" },
                    { 5, "Çorba Yemekleri", "Çorba" }
                });

            migrationBuilder.InsertData(
                table: "YemekTarifleri",
                columns: new[] { "TarifId", "Aciklama", "Baslik", "IsActive", "KategoriId", "Malzeme", "Resim", "Sure", "TarifAciklama", "TurId", "UserId", "kisiSayisi" },
                values: new object[,]
                {
                    { 1, "Aciklama", "İmam bayıldı", true, 1, "Tuz, Patlıcan, Lıyma, Domatez", null, 15, "Tarif", 4, 1, "4-6" },
                    { 2, "Aciklama", "Kebap", true, 1, "Tuz, Kıyma, Biber", null, 10, "Tarif", 1, 2, "4-6" }
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
