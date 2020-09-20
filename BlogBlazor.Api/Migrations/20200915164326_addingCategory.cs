using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogBlazor.Api.Migrations
{
    public partial class addingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kategoris",
                columns: new[] { "Id", "KategoriName" },
                values: new object[] { 1, "Programming" });

            migrationBuilder.InsertData(
                table: "Kategoris",
                columns: new[] { "Id", "KategoriName" },
                values: new object[] { 2, "Breaking News" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_KategoriId",
                table: "Posts",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Kategoris_KategoriId",
                table: "Posts",
                column: "KategoriId",
                principalTable: "Kategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Kategoris_KategoriId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Kategoris");

            migrationBuilder.DropIndex(
                name: "IX_Posts_KategoriId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Body", "Summary", "Title" },
                values: new object[] { 1, "Aji Mustofa", "Post by aji mustofa", "Post pertama", "Post Aji" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Body", "Summary", "Title" },
                values: new object[] { 2, "Gina", "Post by gina", "Post kedua", "Post Gina" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Body", "Summary", "Title" },
                values: new object[] { 3, "Pepeg", "Post by pepega", "Post ketiga", "Post KEKW" });
        }
    }
}
