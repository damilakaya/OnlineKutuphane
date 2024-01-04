using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje1.Migrations
{
    /// <inheritdoc />
    public partial class KiralamalarTablosuEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitapTurleri_KitapTurleri_KitapTuruId",
                table: "KitapTurleri");

            migrationBuilder.DropIndex(
                name: "IX_KitapTurleri_KitapTuruId",
                table: "KitapTurleri");

            migrationBuilder.DropColumn(
                name: "KitapTuruId",
                table: "KitapTurleri");

            migrationBuilder.CreateTable(
                name: "Kiralamalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KitapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiralamalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kiralamalar_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kiralamalar_KitapId",
                table: "Kiralamalar",
                column: "KitapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kiralamalar");

            migrationBuilder.AddColumn<int>(
                name: "KitapTuruId",
                table: "KitapTurleri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KitapTurleri_KitapTuruId",
                table: "KitapTurleri",
                column: "KitapTuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTurleri_KitapTurleri_KitapTuruId",
                table: "KitapTurleri",
                column: "KitapTuruId",
                principalTable: "KitapTurleri",
                principalColumn: "Id");
        }
    }
}
