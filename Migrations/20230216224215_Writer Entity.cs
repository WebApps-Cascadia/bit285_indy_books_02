using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndyBooks.Migrations
{
    public partial class WriterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<long>(
                name: "Authorid",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authorid",
                table: "Books",
                column: "Authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writers_Authorid",
                table: "Books",
                column: "Authorid",
                principalTable: "Writers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writers_Authorid",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Books_Authorid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Authorid",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }
    }
}
