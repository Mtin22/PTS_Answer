using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_App.Migrations
{
    /// <inheritdoc />
    public partial class Build3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Enrolment_Date",
                table: "Students",
                newName: "EnrolmentDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrolmentDate",
                table: "Students",
                newName: "Enrolment_Date");
        }
    }
}
