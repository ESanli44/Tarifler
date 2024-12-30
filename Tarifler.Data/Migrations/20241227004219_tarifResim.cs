using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarifler.Data.Migrations
{
    /// <inheritdoc />
    public partial class tarifResim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 1,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 2, 42, 17, 696, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 2,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 2, 42, 17, 696, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 3,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 2, 42, 17, 696, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 1,
                column: "Resim",
                value: "bayildi.webp");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 2,
                column: "Resim",
                value: "Kebap.jpg");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 3,
                column: "Resim",
                value: "ezme-salata.webp");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 4,
                column: "Resim",
                value: "humus.jpeg");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 5,
                column: "Resim",
                value: "pilav.webp");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 6,
                column: "Resim",
                value: "levrek.webp");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 7,
                column: "Resim",
                value: "tavuk-sote.webp");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 8,
                column: "Resim",
                value: "anali-kizli-yemegi.jpg");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 9,
                column: "Resim",
                value: "yas-pasta.webp");

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 10,
                columns: new[] { "Aciklama", "Resim" },
                values: new object[] { "Dokusu kıvamı lezzeti harika olan tatlı tarifi bırakıyorum buraya.\r\n\r\nSe,vdiklerinizle paylaşmayı unutmayın.", "burma.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 1,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 2, 21, 21, 640, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 2,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 2, 21, 21, 640, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "Mesajlar",
                keyColumn: "MesajId",
                keyValue: 3,
                column: "Tarih",
                value: new DateTime(2024, 12, 27, 2, 21, 21, 640, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 1,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 2,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 3,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 4,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 5,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 6,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 7,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 8,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 9,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YemekTarifleri",
                keyColumn: "TarifId",
                keyValue: 10,
                columns: new[] { "Aciklama", "Resim" },
                values: new object[] { "Dokusu kıvamı lezzeti harika olan tatlı tarifi bırakıyorum buraya.\r\n\r\nSevdiklerinizle paylaşmayı unutmayın.", null });
        }
    }
}
