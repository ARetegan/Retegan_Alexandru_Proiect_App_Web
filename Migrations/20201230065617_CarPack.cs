using Microsoft.EntityFrameworkCore.Migrations;

namespace Retegan_Alexandru_Proiect_App_Web.Migrations
{
    public partial class CarPack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarPack",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    PackID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPack", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarPack_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPack_Pack_PackID",
                        column: x => x.PackID,
                        principalTable: "Pack",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPack_OrderID",
                table: "CarPack",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CarPack_PackID",
                table: "CarPack",
                column: "PackID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPack");

            migrationBuilder.DropTable(
                name: "Pack");
        }
    }
}
