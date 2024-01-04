using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje1.Migrations
{
    /// <inheritdoc />
    public partial class mig_5Ekle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                        CREATE PROCEDURE sp_TurKitaplar
                        AS
                        SELECT TOP 100 kt.Name, COUNT(*) FROM KitapTurleri kt
                         JOIN Kitaplar k
                            ON kt.Id = k.Id
                        GROUP By kt.Name
                        ORDER By COUNT(*) DESC
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_TurKitaplar");
        }
    }
}
