using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_App.Migrations
{
    /// <inheritdoc />
    public partial class Build5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Regiser",
                table: "Regiser");

            migrationBuilder.RenameTable(
                name: "Regiser",
                newName: "Register");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "Regiser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regiser",
                table: "Regiser",
                column: "Id");
        }
    }
}
