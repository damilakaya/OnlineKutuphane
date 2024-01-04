using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje1.Migrations
{
    /// <inheritdoc />
    public partial class Mig_4Ekle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                        CREATE PROCEDURE sp_KitaplarınKiralamaları
                        AS
                        SELECT TOP 100 k.KitapAdi, COUNT(*) FROM Kitaplar k
                         JOIN Kiralamalar kr
                            ON k.Id = kr.Id
                        GROUP By k.KitapAdi
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_KitaplarınKiralamaları");

        }
    }
}
