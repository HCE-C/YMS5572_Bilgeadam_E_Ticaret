using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret.Model.Migrations
{
    public partial class OrderRelationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddress_Order_OrderId",
                table: "BillingAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddress_Order_OrderId",
                table: "ShippingAddress");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddress_OrderId",
                table: "ShippingAddress");

            migrationBuilder.DropIndex(
                name: "IX_BillingAddress_OrderId",
                table: "BillingAddress");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BillingAddress");

            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123456");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BillingAddressId",
                table: "Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingAddressId",
                table: "Order",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_BillingAddress_BillingAddressId",
                table: "Order",
                column: "BillingAddressId",
                principalTable: "BillingAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingAddress_ShippingAddressId",
                table: "Order",
                column: "ShippingAddressId",
                principalTable: "ShippingAddress",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_BillingAddress_BillingAddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingAddress_ShippingAddressId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BillingAddressId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingAddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShippingAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "BillingAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_OrderId",
                table: "ShippingAddress",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_OrderId",
                table: "BillingAddress",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddress_Order_OrderId",
                table: "BillingAddress",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddress_Order_OrderId",
                table: "ShippingAddress",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
