using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStock_TShirt_TshirtId",
                table: "AppStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_TShirt_TshirtId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TShirt",
                table: "TShirt");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cb37b59-48cd-49de-bb32-c2cdc9984925");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9801b9-64d0-4034-81b5-3f0518f64a7b");

            migrationBuilder.RenameTable(
                name: "TShirt",
                newName: "TShirts");

            migrationBuilder.RenameColumn(
                name: "TshirtId",
                table: "AppStock",
                newName: "TShirtId");

            migrationBuilder.RenameIndex(
                name: "IX_AppStock_TshirtId",
                table: "AppStock",
                newName: "IX_AppStock_TShirtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TShirts",
                table: "TShirts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8be39ffc-c052-4e00-8394-d0b9d54b1478", null, "Admin", "ADMIN" },
                    { "e3426b52-1fcd-454b-a7c2-2f81552fc9ab", null, "USer", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AppStock_TShirts_TShirtId",
                table: "AppStock",
                column: "TShirtId",
                principalTable: "TShirts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_TShirts_TshirtId",
                table: "Reviews",
                column: "TshirtId",
                principalTable: "TShirts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStock_TShirts_TShirtId",
                table: "AppStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_TShirts_TshirtId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TShirts",
                table: "TShirts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be39ffc-c052-4e00-8394-d0b9d54b1478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3426b52-1fcd-454b-a7c2-2f81552fc9ab");

            migrationBuilder.RenameTable(
                name: "TShirts",
                newName: "TShirt");

            migrationBuilder.RenameColumn(
                name: "TShirtId",
                table: "AppStock",
                newName: "TshirtId");

            migrationBuilder.RenameIndex(
                name: "IX_AppStock_TShirtId",
                table: "AppStock",
                newName: "IX_AppStock_TshirtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TShirt",
                table: "TShirt",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cb37b59-48cd-49de-bb32-c2cdc9984925", null, "USer", "USER" },
                    { "9c9801b9-64d0-4034-81b5-3f0518f64a7b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AppStock_TShirt_TshirtId",
                table: "AppStock",
                column: "TshirtId",
                principalTable: "TShirt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_TShirt_TshirtId",
                table: "Reviews",
                column: "TshirtId",
                principalTable: "TShirt",
                principalColumn: "Id");
        }
    }
}
