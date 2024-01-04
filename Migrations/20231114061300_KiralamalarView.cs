using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje1.Migrations
{
    /// <inheritdoc />
    public partial class KiralamalarView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                        CREATE VIEW vm_KiralamalarView
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
                        DROP VIEW vm_KiralamalarView
            ");
        }
    }
}
