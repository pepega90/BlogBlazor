using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogBlazor.Api.Migrations
{
    public partial class fixKategoriModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Kategoris_KategoriId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Kategoris_KategoriId",
                table: "Posts",
                column: "KategoriId",
                principalTable: "Kategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Kategoris_KategoriId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Kategoris_KategoriId",
                table: "Posts",
                column: "KategoriId",
                principalTable: "Kategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
