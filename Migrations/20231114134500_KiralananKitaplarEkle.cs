using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje1.Migrations
{
    /// <inheritdoc />
    public partial class KiralananKitaplarEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                        CREATE VIEW vm_KiralananKitaplarView
                        AS
                        SELECT TOP 100 kr.Id, COUNT(*) [Count] FROM Kiralamalar kr
                        INNER JOIN Kitaplar k
                            ON kr.Id = k.Id
                        GROUP By kr.Id
                        ORDER By [count] DESC 
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@" 
                    DROP PROC sp_KiralananKitaplar");

        }
    }
}
