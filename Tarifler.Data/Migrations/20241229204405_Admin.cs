using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarifler.Data.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "UserId", "FirstName", "IsActive", "IsAdmin", "IsGuest", "IsMember", "LastName", "UserEmail", "UserName", "UserPassword", "UserPhone" },
                values: new object[] { 5, "Admin", true, true, false, false, "Admin", "Admin@gmail.com", "Admin", "Admin.123", "11111111111" });

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 1,
                column: "Tarih",
                value: new DateTime(2024, 12, 29, 22, 44, 0, 644, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 2,
                column: "Tarih",
                value: new DateTime(2024, 12, 29, 22, 44, 0, 644, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 3,
                column: "Tarih",
                value: new DateTime(2024, 12, 29, 22, 44, 0, 644, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "SliderId",
                keyValue: 2,
                column: "Icerik",
                value: "Hamburgerin Zirvesine Yolculuk: Usta Aşçılardan Efsane Tarifler!\r\n\r\nYemek sitemizde, hamburgerin en lezzetli halini deneyimlemeye hazır olun! Usta aşçılarımız, klasik ve yaratıcı hamburger tarifleriyle mutfaklarınıza eşsiz bir tat katıyor. Her biri, sadece lezzet değil, aynı zamanda özenli bir ustalıkla hazırlanmış hamburgerler sunmak için titizlikle çalışıyor.\r\n\r\nAşçılarımız, hamburgerin geleneksel tariflerini bir adım daha öteye taşıyarak, malzeme seçiminden pişirme tekniklerine kadar her detayı mükemmel hale getiriyor. Efsane köfteler, taze ve kaliteli malzemeler, özgün soslar ve ekler, hamburgeri adeta bir sanat eserine dönüştürüyor. Her lokmada, lezzetlerin dansı ve eşsiz uyumu sizi bekliyor.\r\n\r\nHamburgerlerimiz, yalnızca doyurucu değil, aynı zamanda her damak zevkine hitap eden, özgün kombinasyonlarla bezenmiş. Dilerseniz klasik Amerikan tarzı bir hamburgerin keyfini çıkarabilir, dilerseniz deniz ürünleri veya vejetaryen seçeneklerle farklı tatlar keşfedebilirsiniz. Aşçılarımız, her tarifte benzersiz bir dokunuşla hamburgeri yeniden keşfetmenizi sağlıyor.\r\n\r\nHer bir hamburger, aşçılarımızın mutfakta geçirdiği yılların bir yansıması olarak, sadece lezzet değil, aynı zamanda bir deneyim sunuyor. Hamburgerin sadece bir yemek değil, bir tutkuyla hazırlandığını hissedeceksiniz.\r\n\r\nHamburgerin en özel halini keşfetmek için hemen sitemize göz atın, aşçılarımızın eşsiz tarifleriyle damağınızda unutulmaz tatlar bırakın!");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 1,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 15, 52, 16, 586, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 2,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 15, 52, 16, 586, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 3,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 15, 52, 16, 586, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "SliderId",
                keyValue: 2,
                column: "Icerik",
                value: "amburgerin Zirvesine Yolculuk: Usta Aşçılardan Efsane Tarifler!\r\n\r\nYemek sitemizde, hamburgerin en lezzetli halini deneyimlemeye hazır olun! Usta aşçılarımız, klasik ve yaratıcı hamburger tarifleriyle mutfaklarınıza eşsiz bir tat katıyor. Her biri, sadece lezzet değil, aynı zamanda özenli bir ustalıkla hazırlanmış hamburgerler sunmak için titizlikle çalışıyor.\r\n\r\nAşçılarımız, hamburgerin geleneksel tariflerini bir adım daha öteye taşıyarak, malzeme seçiminden pişirme tekniklerine kadar her detayı mükemmel hale getiriyor. Efsane köfteler, taze ve kaliteli malzemeler, özgün soslar ve ekler, hamburgeri adeta bir sanat eserine dönüştürüyor. Her lokmada, lezzetlerin dansı ve eşsiz uyumu sizi bekliyor.\r\n\r\nHamburgerlerimiz, yalnızca doyurucu değil, aynı zamanda her damak zevkine hitap eden, özgün kombinasyonlarla bezenmiş. Dilerseniz klasik Amerikan tarzı bir hamburgerin keyfini çıkarabilir, dilerseniz deniz ürünleri veya vejetaryen seçeneklerle farklı tatlar keşfedebilirsiniz. Aşçılarımız, her tarifte benzersiz bir dokunuşla hamburgeri yeniden keşfetmenizi sağlıyor.\r\n\r\nHer bir hamburger, aşçılarımızın mutfakta geçirdiği yılların bir yansıması olarak, sadece lezzet değil, aynı zamanda bir deneyim sunuyor. Hamburgerin sadece bir yemek değil, bir tutkuyla hazırlandığını hissedeceksiniz.\r\n\r\nHamburgerin en özel halini keşfetmek için hemen sitemize göz atın, aşçılarımızın eşsiz tarifleriyle damağınızda unutulmaz tatlar bırakın!");
        }
    }
}
