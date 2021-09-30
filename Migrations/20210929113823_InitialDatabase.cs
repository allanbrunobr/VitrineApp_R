using Microsoft.EntityFrameworkCore.Migrations;

namespace VitrineApp_R.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brand = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<string>(type: "TEXT", nullable: true),
                    imageLink = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    productType = table.Column<string>(type: "TEXT", nullable: true),
                    category = table.Column<string>(type: "TEXT", nullable: true),
                    tagList = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoresDisponiveis",
                columns: table => new
                {
                    hexValue = table.Column<string>(type: "TEXT", nullable: false),
                    nomeCor = table.Column<string>(type: "TEXT", nullable: true),
                    Itemid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoresDisponiveis", x => x.hexValue);
                    table.ForeignKey(
                        name: "FK_CoresDisponiveis_Item_Itemid",
                        column: x => x.Itemid,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoresDisponiveis_Itemid",
                table: "CoresDisponiveis",
                column: "Itemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoresDisponiveis");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
