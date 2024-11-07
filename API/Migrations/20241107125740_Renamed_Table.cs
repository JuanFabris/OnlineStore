using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Renamed_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredFoot",
                table: "Avatars",
                newName: "FavouriteFoot");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Avatars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Avatars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Avatars");

            migrationBuilder.RenameColumn(
                name: "FavouriteFoot",
                table: "Avatars",
                newName: "PreferredFoot");

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Avatars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
