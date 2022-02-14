using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDDD.Migrations
{
    public partial class addmigrationEntities_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Products_ProductId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ProductId",
                table: "Purchase");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Purchase",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PurchaseId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_AccountId",
                table: "Purchase",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseId",
                table: "Products",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchase_PurchaseId",
                table: "Products",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Accounts_AccountId",
                table: "Purchase",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchase_PurchaseId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Accounts_AccountId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_AccountId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProductId",
                table: "Purchase",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Products_ProductId",
                table: "Purchase",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
