using Microsoft.EntityFrameworkCore.Migrations;

namespace Retegan_Alexandru_Proiect_App_Web.Migrations
{
    public partial class Fuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelID",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_FuelID",
                table: "Order",
                column: "FuelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Fuel_FuelID",
                table: "Order",
                column: "FuelID",
                principalTable: "Fuel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Fuel_FuelID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropIndex(
                name: "IX_Order_FuelID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FuelID",
                table: "Order");
        }
    }
}
