using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcvcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVBase64",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVBase64",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobApplications");
        }
    }
}
